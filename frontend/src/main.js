import Vue from 'vue'
import App from './App.vue'

import vuetify from './plugins/vuetify.js'
import router from './router/router.js'

import ApiService from './common/api.service.js';
import LoadingVue from './plugins/LoadingVue.js'

Vue.config.productionTip = false;
Vue.config.performance = true;
Vue.config.silent = true

ApiService.init();

new Vue({
  router,
  vuetify,
  LoadingVue,
  render: h => h(App),
}).$mount('#app')
