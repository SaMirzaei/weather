<template>
  <div id="app">
    <Header />
    <div class="container" style="margin-top: 20px; margin-bottom: 20px;">
      <div class="row">
        <div class="col-md-12">
          <form style="margin:5px;">
            <div class="form-row">
              <div class="col-12 col-md-9 mb-2 mb-md-0">
                <input
                  type="text"
                  v-model="city"
                  class="form-control form-control-lg"
                  placeholder="Enter a town, city or GR postcode..."
                />
              </div>
              <div class="col-12 col-md-3">
                <button
                  type="button"
                  class="btn btn-block btn-lg btn-primary"
                  v-on:click="searchWeather"
                >Search!</button>
              </div>
            </div>
          </form>
        </div>
      </div>

      <div class="row" style="margin-top: 20px; margin-bottom: 20px;">
        <div class="col-md-2" v-for="(weather, index) in weathers" :key="weather.dateTime">
          <div class="weather">
            <div class="current">
              <div class="info">
                <div>&nbsp;</div>
                <div class="city">
                  <small>
                    <small>CITY:</small>
                  </small>
                  {{ weather.city }},{{ weather.coutnry }}
                </div>
                <div class="temp">
                  {{Number(weather.maxTemperature).toFixed(0)}}/{{Number(weather.minTemperature).toFixed(0)}}&deg;
                  <small>C</small>
                </div>
                <div class="wind">
                  <small>
                    <small>WIND:</small>
                  </small>
                  {{weather.wind}} km/h
                </div>
                <div class="wind">
                  <small>
                    <small>HUMIDITY:</small>
                  </small>
                  {{weather.humidity}}%
                </div>
                <div>&nbsp;</div>
              </div>
              <div class="icon">
                <span class="wi-day-sunny"></span>
              </div>
            </div>
            <div class="future">
              <div class="day" :class="{ 'current-weather': index === 0 }">
                <h4 class="date">{{weather.dateTime | formatDate }}</h4>
              </div>
            </div>
          </div>
        </div>
      </div>

      <table class="table">
        <thead class="thead-dark">
          <tr>
            <th scope="col">
              DAY
            </th>
            <th scope="col">
              DESCRIPTION
            </th>
            <th scope="col">HIGH / LOW</th>
            <th scope="col">WIND</th>
            <th scope="col">HUMIDITY</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="history in historyWeathers" :key="history.dateTime">
            <th scope="row">{{history.dateTime | formatDate }}</th>
            <td>
              {{history.description}}
              <i
                class="icon"
                style="background: url(https://www.amcharts.com/wp-content/themes/amcharts4/css/img/icons/weather/animated/cloudy-day-1.svg) no-repeat; background-size: contain;"
              ></i>
            </td>
            <td>{{history.highTemperature}}° / {{history.lowTemperature}}°</td>
            <td>{{history.wind}} km/h</td>
            <td>{{history.humidity}}%</td>
          </tr>
        </tbody>
      </table>
    </div>

    <Footer />
    
  </div>
</template>

<script>
import Header from "./components/Header.vue";
import Footer from "./components/Footer.vue";
import axios from "axios";

export default {
  name: "app",
  components: {
    Header,
    Footer
  },
  data() {
    return {
      weathers: [],
      historyWeathers: [],
      city: "Leipzig"
    };
  },
  computed: {
    axiosParams() {
      const params = new URLSearchParams();
      params.append("city", this.city);
      params.append("zipCode", this.city);
      return params;
    }
  },
  created() {
    this.fetch();
  },
  methods: {
    fetch() {
      axios
        .get("http://localhost:5000/v1/weather/forecast", {
          params: this.axiosParams
        })
        .then(response => {
          this.weathers = response.data;

          this.history(this.city);
        })
        .catch(e => {
          this.errors.push(e);
        });
    },
    history(city) {
      axios
        .get("http://localhost:5000/v1/weather/history/" + city)
        .then(response => {
          this.historyWeathers = response.data;
        })
        .catch(e => {
          this.errors.push(e);
        });
    },
    searchWeather() {
      this.fetch();
    }
  }
};
</script>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
.current-weather {
  color: #fff;
    background-color: #f68d2e;
}
.date {
  font-size: 1.2rem;
  text-align: center;
  padding-top: 5px;
}

.weather {
  display: flex;
  flex-flow: column wrap;
  box-shadow: 0px 1px 10px 0px #cfcfcf;
  overflow: hidden;
}

.weather .current {
  display: flex;
  flex-flow: row wrap;
  background-image: url("http://www.prepbootstrap.com/Content/images/shared/misc/london-view.png");
  background-repeat: repeat-x;
  color: white;
  text-shadow: 1px 1px #f68d2e;
}

.weather .current .info {
  display: flex;
  flex-flow: column wrap;
  justify-content: space-around;
  flex-grow: 2;
}

.weather .current .info .city {
  font-size: 26px;
}

.weather .current .icon {
  margin: 0;
  width: 80px;
  height: 80px;
  -webkit-box-flex: 1;
  -ms-flex-positive: 1;
  flex-grow: 1;
  background: url(https://www.amcharts.com/wp-content/themes/amcharts4/css/img/icons/weather/animated/cloudy-day-1.svg)
    50% 50% / contain no-repeat;
}

.weather .future {
  display: flex;
  flex-flow: row nowrap;
}

.weather .future .day {
  flex-grow: 1;
  text-align: center;
  cursor: pointer;
}

.weather .future .day:hover {
  color: #fff;
  background-color: #f68d2e;
}

.weather .future .day h3 {
  text-transform: uppercase;
}

.weather .future .day p {
  font-size: 28px;
}

/* footer */
footer {
  background: #222;
  color: #aaa;
  padding-top: 10px;
}

footer a {
  color: #aaa;
}

footer a:hover {
  color: #fff;
}

footer h3 {
  color: #0894d1;
  letter-spacing: 1px;
  margin: 30px 0 20px;
}

footer .three-column {
  overflow: hidden;
}

footer .three-column li {
  width: 33.3333%;
  float: left;
  padding: 5px 0;
}

footer .socila-list {
  overflow: hidden;
  margin: 20px 0 10px;
}

footer .socila-list li {
  float: left;
  margin-right: 3px;
  opacity: 0.7;
  overflow: hidden;
  border-radius: 50%;
  transition: all 0.3s ease-in-out;
}

footer .socila-list li:hover {
  opacity: 1;
}

footer .img-thumbnail {
  background: rgba(0, 0, 0, 0.2);
  border: 1px solid #444;
  margin-bottom: 5px;
}

footer .copyright {
  padding: 15px 0;
  background: #333;
  margin-top: 20px;
  font-size: 15px;
}

footer .copyright span {
  color: #0894d1;
}

/* weather */
.icon.bigger {
  width: 57px;
  height: 57px;
}
.icon {
  width: 34px;
  height: 34px;
  display: inline-block;
  vertical-align: middle;
  margin: -3px 12px 0 0;
  background-size: contain;
  background-position: center center;
  background-repeat: no-repeat;
  text-indent: -9999px;
}
</style>
