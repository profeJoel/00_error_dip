import { createApp } from 'vue'
import App from './components/App.vue'
import router from './router'

import './assets/main.css'
import 'bootstrap/dist/css/bootstrap.css'
import bootstrap from 'bootstrap/dist/js/bootstrap.bundle.js'

import axios from 'axios'

createApp(App).use(router, bootstrap).mount('#app')
