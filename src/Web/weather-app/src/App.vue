<template>
  <div id="app">
    <Header />

<div class="container">
<div class="row">
        <div class="col-md-12">
          <form style="margin:5px;">
            <div class="form-row">
              <div class="col-12 col-md-9 mb-2 mb-md-0">
                <input type="text" class="form-control form-control-lg" placeholder="Enter a town, city or GR postcode...">
              </div>
              <div class="col-12 col-md-3">
                <button type="submit" class="btn btn-block btn-lg btn-primary">Sign up!</button>
              </div>
            </div>
          </form>
        </div>
      </div>
</div>

<div class="container">
    <div class="row">
        <div class="col-md-4 col-md-offset-4">
            <div class="weather">
                <div class="current">
                    <div class="info">
                        <div>&nbsp;</div>
                        <div class="city"><small><small>CITY:</small></small> London</div>
                        <div class="temp">67&deg; <small>F</small></div>
                        <div class="wind"><small><small>WIND:</small></small> 22 km/h</div>
                        <div>&nbsp;</div>
                    </div>
                    <div class="icon">
                        <span class="wi-day-sunny"></span>
                    </div>
                </div>
                <div class="future">
                    <div class="day">
                        <h3>Mon</h3>
                        <p><span class="wi-day-cloudy"></span></p>
                    </div>
                    <div class="day">
                        <h3>Tue</h3>
                        <p><span class="wi-showers"></span></p>
                    </div>
                    <div class="day">
                        <h3>Wed</h3>
                        <p><span class="wi-rain"></span></p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<link rel="stylesheet" type="text/css" href="/Content/css/weather-icons/css/weather-icons.min.css" />
<!-- http://www.prepbootstrap.com/bootstrap-template/weather-widget -->
<!-- https://www.bbc.co.uk/weather/2643743 -->

    <img alt="Vue logo" src="./assets/light-rain-shower-day.jpg">
    <HelloWorld msg="Welcome to Your Vue.js App" />
  </div>
</template>

<script>
import HelloWorld from "./components/HelloWorld.vue";
import Header from "./components/Header.vue";

export default {
  name: "app",
  components: {
    HelloWorld,
    Header
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
.weather
    {
        display: flex;
        flex-flow: column wrap;
        box-shadow: 0px 1px 10px 0px #cfcfcf;
        overflow: hidden;
    }

        .weather .current
        {
            display: flex;
            flex-flow: row wrap;
            background-image: url("http://www.prepbootstrap.com/Content/images/shared/misc/london-view.png");
            background-repeat: repeat-x;
            color: white;
            padding: 20px;
            text-shadow: 1px 1px #F68D2E;
        }

            .weather .current .info
            {
                display: flex;
                flex-flow: column wrap;
                justify-content: space-around;
                flex-grow: 2;
            }

                .weather .current .info .city
                {
                    font-size: 26px;
                }

                .weather .current .info .temp
                {
                    font-size: 56px;
                }

                .weather .current .info .wind
                {
                    font-size: 24px;
                }

            .weather .current .icon
            {
                text-align: center;
                font-size: 64px;
                flex-grow: 1;
            }

        .weather .future
        {
            display: flex;
            flex-flow: row nowrap;
        }

            .weather .future .day
            {
                flex-grow: 1;
                text-align: center;
                cursor: pointer;
            }

                .weather .future .day:hover
                {
                    color: #fff;
                    background-color: #F68D2E;
                }

                .weather .future .day h3
                {
                    text-transform: uppercase;
                }

                .weather .future .day p
                {
                    font-size: 28px;
                }
</style>
