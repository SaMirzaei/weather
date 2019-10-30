<template>
  <div id="app">
    <Header />
    <ul v-if="weathers && weathers.length">
      <li v-for="wather of weathers">
        <p>
          <strong>{{wather.title}}</strong>
        </p>
        <p>{{wather.body}}</p>
      </li>
    </ul>

    <div class="container" style="margin-top: 20px; margin-bottom: 20px;">
      <div class="row">
        <div class="col-md-12">
          <form style="margin:5px;">
            <div class="form-row">
              <div class="col-12 col-md-9 mb-2 mb-md-0">
                <input
                  type="text"
                  class="form-control form-control-lg"
                  placeholder="Enter a town, city or GR postcode..."
                />
              </div>
              <div class="col-12 col-md-3">
                <button type="submit" class="btn btn-block btn-lg btn-primary">Search!</button>
              </div>
            </div>
          </form>
        </div>
      </div>

      <div class="row" style="margin-top: 20px">
        <div class="col-md-12">
          <div class="weather">
            <div class="current">
              <div class="info">
                <div>&nbsp;</div>
                <div class="city">
                  <small>
                    <small>CITY:</small>
                  </small> London
                </div>
                <div class="temp">
                  67&deg;
                  <small>F</small>
                </div>
                <div class="wind">
                  <small>
                    <small>WIND:</small>
                  </small> 22 km/h
                </div>
                <div>&nbsp;</div>
              </div>
              <div class="icon">
                <span class="wi-day-sunny"></span>
              </div>
            </div>
            <div class="future">
              <div class="day">
                <h3>Mon</h3>
                <p>
                  <span class="wi-day-cloudy"></span>
                </p>
              </div>
              <div class="day">
                <h3>Tue</h3>
                <p>
                  <span class="wi-showers"></span>
                </p>
              </div>
              <div class="day">
                <h3>Wed</h3>
                <p>
                  <span class="wi-rain"></span>
                </p>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div class="row" style="margin-top: 20px; margin-bottom: 20px;">
        <div class="col-md-2 col-md-offset-2">
          <div class="weather">
            <div class="current">
              <div class="info">
                <div>&nbsp;</div>
                <div class="city">
                  <small>
                    <small>CITY:</small>
                  </small> London
                </div>
                <div class="temp">
                  67&deg;
                  <small>F</small>
                </div>
                <div class="wind">
                  <small>
                    <small>WIND:</small>
                  </small> 22 km/h
                </div>
                <div>&nbsp;</div>
              </div>
              <div class="icon">
                <span class="wi-day-sunny"></span>
              </div>
            </div>
            <div class="future">
              <div class="day">
                <h3>Mon</h3>
                <p>
                  <span class="wi-day-cloudy"></span>
                </p>
              </div>
              <div class="day">
                <h3>Tue</h3>
                <p>
                  <span class="wi-showers"></span>
                </p>
              </div>
              <div class="day">
                <h3>Wed</h3>
                <p>
                  <span class="wi-rain"></span>
                </p>
              </div>
            </div>
          </div>
        </div>
        <div class="col-md-2 col-md-offset-2">
          <div class="weather">
            <div class="current">
              <div class="info">
                <div>&nbsp;</div>
                <div class="city">
                  <small>
                    <small>CITY:</small>
                  </small> London
                </div>
                <div class="temp">
                  67&deg;
                  <small>F</small>
                </div>
                <div class="wind">
                  <small>
                    <small>WIND:</small>
                  </small> 22 km/h
                </div>
                <div>&nbsp;</div>
              </div>
              <div class="icon">
                <span class="wi-day-sunny"></span>
              </div>
            </div>
            <div class="future">
              <div class="day">
                <h3>Mon</h3>
                <p>
                  <span class="wi-day-cloudy"></span>
                </p>
              </div>
              <div class="day">
                <h3>Tue</h3>
                <p>
                  <span class="wi-showers"></span>
                </p>
              </div>
              <div class="day">
                <h3>Wed</h3>
                <p>
                  <span class="wi-rain"></span>
                </p>
              </div>
            </div>
          </div>
        </div>
        <div class="col-md-2 col-md-offset-2">
          <div class="weather">
            <div class="current">
              <div class="info">
                <div>&nbsp;</div>
                <div class="city">
                  <small>
                    <small>CITY:</small>
                  </small> London
                </div>
                <div class="temp">
                  67&deg;
                  <small>F</small>
                </div>
                <div class="wind">
                  <small>
                    <small>WIND:</small>
                  </small> 22 km/h
                </div>
                <div>&nbsp;</div>
              </div>
              <div class="icon">
                <span class="wi-day-sunny"></span>
              </div>
            </div>
            <div class="future">
              <div class="day">
                <h3>Mon</h3>
                <p>
                  <span class="wi-day-cloudy"></span>
                </p>
              </div>
              <div class="day">
                <h3>Tue</h3>
                <p>
                  <span class="wi-showers"></span>
                </p>
              </div>
              <div class="day">
                <h3>Wed</h3>
                <p>
                  <span class="wi-rain"></span>
                </p>
              </div>
            </div>
          </div>
        </div>
        <div class="col-md-2 col-md-offset-2">
          <div class="weather">
            <div class="current">
              <div class="info">
                <div>&nbsp;</div>
                <div class="city">
                  <small>
                    <small>CITY:</small>
                  </small> London
                </div>
                <div class="temp">
                  67&deg;
                  <small>F</small>
                </div>
                <div class="wind">
                  <small>
                    <small>WIND:</small>
                  </small> 22 km/h
                </div>
                <div>&nbsp;</div>
              </div>
              <div class="icon">
                <span class="wi-day-sunny"></span>
              </div>
            </div>
            <div class="future">
              <div class="day">
                <h3>Mon</h3>
                <p>
                  <span class="wi-day-cloudy"></span>
                </p>
              </div>
              <div class="day">
                <h3>Tue</h3>
                <p>
                  <span class="wi-showers"></span>
                </p>
              </div>
              <div class="day">
                <h3>Wed</h3>
                <p>
                  <span class="wi-rain"></span>
                </p>
              </div>
            </div>
          </div>
        </div>
        <div class="col-md-2 col-md-offset-2">
          <div class="weather">
            <div class="current">
              <div class="info">
                <div>&nbsp;</div>
                <div class="city">
                  <small>
                    <small>CITY:</small>
                  </small> London
                </div>
                <div class="temp">
                  67&deg;
                  <small>F</small>
                </div>
                <div class="wind">
                  <small>
                    <small>WIND:</small>
                  </small> 22 km/h
                </div>
                <div>&nbsp;</div>
              </div>
              <div class="icon">
                <span class="wi-day-sunny"></span>
              </div>
            </div>
            <div class="future">
              <div class="day">
                <h3>Mon</h3>
                <p>
                  <span class="wi-day-cloudy"></span>
                </p>
              </div>
              <div class="day">
                <h3>Tue</h3>
                <p>
                  <span class="wi-showers"></span>
                </p>
              </div>
              <div class="day">
                <h3>Wed</h3>
                <p>
                  <span class="wi-rain"></span>
                </p>
              </div>
            </div>
          </div>
        </div>
        <div class="col-md-2 col-md-offset-2">
          <div class="weather">
            <div class="current">
              <div class="info">
                <div>&nbsp;</div>
                <div class="city">
                  <small>
                    <small>CITY:</small>
                  </small> London
                </div>
                <div class="temp">
                  67&deg;
                  <small>F</small>
                </div>
                <div class="wind">
                  <small>
                    <small>WIND:</small>
                  </small> 22 km/h
                </div>
                <div>&nbsp;</div>
              </div>
              <div class="icon">
                <span class="wi-day-sunny"></span>
              </div>
            </div>
            <div class="future">
              <div class="day">
                <h3>Mon</h3>
                <p>
                  <span class="wi-day-cloudy"></span>
                </p>
              </div>
              <div class="day">
                <h3>Tue</h3>
                <p>
                  <span class="wi-showers"></span>
                </p>
              </div>
              <div class="day">
                <h3>Wed</h3>
                <p>
                  <span class="wi-rain"></span>
                </p>
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
              <i
                class="icon bigger"
                style="background: url('https://www.amcharts.com/wp-content/themes/amcharts4/css/img/icons/weather/animated/cloudy-day-1.svg') no-repeat; background-size: contain;"
              ></i>
            </th>
            <th scope="col">
              DESCRIPTION
              <i
                class="icon"
                style="background: url(https://www.amcharts.com/wp-content/themes/amcharts4/css/img/icons/weather/animated/cloudy-day-1.svg) no-repeat; background-size: contain;"
              ></i>
            </th>
            <th scope="col">HIGH / LOW</th>
            <th scope="col">PRECIP</th>
            <th scope="col">WIND</th>
            <th scope="col">HUMIDITY</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <th scope="row">TODAY OCT 28</th>
            <td>Rain</td>
            <td>60°53°</td>
            <td>80%</td>
            <td>SE 8 mph</td>
            <td>66%</td>
          </tr>
          <tr>
            <th scope="row">TUE OCT 29</th>
            <td>Mostly Sunny</td>
            <td>66°52°</td>
            <td>20%</td>
            <td>WSW 9 mph</td>
            <td>60%</td>
          </tr>
          <tr>
            <th scope="row">TUE OCT 29</th>
            <td>Mostly Sunny</td>
            <td>66°52°</td>
            <td>20%</td>
            <td>WSW 9 mph</td>
            <td>60%</td>
          </tr>
          <tr>
            <th scope="row">TUE OCT 29</th>
            <td>Mostly Sunny</td>
            <td>66°52°</td>
            <td>20%</td>
            <td>WSW 9 mph</td>
            <td>60%</td>
          </tr>
        </tbody>
      </table>
    </div>

    <link
      rel="stylesheet"
      type="text/css"
      href="/Content/css/weather-icons/css/weather-icons.min.css"
    />
    <!-- http://www.prepbootstrap.com/bootstrap-template/weather-widget -->
    <!-- https://www.bbc.co.uk/weather/2643743 -->

    <!-- <div class="row">
      <div class="col-md-12">
        <img alt="Vue logo" src="./assets/light-rain-shower-day.jpg" />
      </div>
    </div>-->

    <!-- <HelloWorld msg="Welcome to Your Vue.js App" /> -->

    <footer>
      <div class="container">
        <div class="row">
          <div class="col-lg-4 col-md-6">
            <h3>Site Map</h3>
            <ul class="list-unstyled three-column">
              <li>Home</li>
              <li>Services</li>
              <li>About</li>
              <li>Code</li>
              <li>Design</li>
              <li>Host</li>
              <li>Contact</li>
              <li>Company</li>
            </ul>
            <ul class="list-unstyled socila-list">
              <li>
                <img src="http://placehold.it/48x48" alt />
              </li>
              <li>
                <img src="http://placehold.it/48x48" alt />
              </li>
              <li>
                <img src="http://placehold.it/48x48" alt />
              </li>
              <li>
                <img src="http://placehold.it/48x48" alt />
              </li>
              <li>
                <img src="http://placehold.it/48x48" alt />
              </li>
              <li>
                <img src="http://placehold.it/48x48" alt />
              </li>
            </ul>
          </div>

          <div class="col-lg-4 col-md-6">
            <h3>latest Articles</h3>
            <div class="media">
              <a href="#" class="pull-left">
                <img src="http://placehold.it/64x64" alt class="media-object" />
              </a>
              <div class="media-body">
                <h4 class="media-heading">Programming</h4>
                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit.</p>
              </div>
            </div>

            <div class="media">
              <a href="#" class="pull-left">
                <img src="http://placehold.it/64x64" alt class="media-object" />
              </a>
              <div class="media-body">
                <h4 class="media-heading">Coding</h4>
                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit.</p>
              </div>
            </div>

            <div class="media">
              <a href="#" class="pull-left">
                <img src="http://placehold.it/64x64" alt class="media-object" />
              </a>
              <div class="media-body">
                <h4 class="media-heading">Web Sesign</h4>
                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit.</p>
              </div>
            </div>
          </div>

          <div class="col-lg-4">
            <h3>Our Work</h3>
            <img class="img-thumbnail" src="http://placehold.it/150x100" alt />
            <img class="img-thumbnail" src="http://placehold.it/150x100" alt />
            <img class="img-thumbnail" src="http://placehold.it/150x100" alt />
            <img class="img-thumbnail" src="http://placehold.it/150x100" alt />
          </div>
        </div>
      </div>
      <div class="copyright text-center">
        Copyright &copy; 2017
        <span>Your Template Name</span>
      </div>
    </footer>
  </div>
</template>

<script>
// import HelloWorld from "./components/HelloWorld.vue";
import Header from "./components/Header.vue";
import axios from "axios";

export default {
  name: "app",
  components: {
    // HelloWorld,
    Header
  },
  data() {
    return {
      weathers: []
    };
  },
  // Fetches posts when the component is created.
  created() {
    axios
      .get("http://localhost:5000/v1/weather/forecast")
      .then(response => {
        this.weathers = response.data;
      })
      .catch(e => {
        this.errors.push(e);
      });
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
  /* margin-top: 60px; */
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
  padding: 20px;
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

.weather .current .info .temp {
  font-size: 56px;
}

.weather .current .info .wind {
  font-size: 24px;
}

.weather .current .icon {
  text-align: center;
  font-size: 64px;
  flex-grow: 1;
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
