import Vue from 'vue'
import App from './App.vue'
import 'bootstrap'
import 'bootstrap/dist/css/bootstrap.min.css'
import moment from 'moment'

Vue.config.productionTip = false

Vue.filter('formatDate', function (value) {
  if (value) {
    return moment(String(value)).format('ddd, MMM D')
  }
})

new Vue({
  render: h => h(App),
}).$mount('#app')
