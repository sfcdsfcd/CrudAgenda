import Aura from '@primevue/themes/aura'
import PrimeVue from 'primevue/config'
import { createApp } from 'vue'
import App from './App.vue'
import './assets/tailwind.css'
import 'primeicons/primeicons.css';
import router from './router'

const app = createApp(App);
app.use(router);
app.use(PrimeVue, {
  theme: {
    preset: Aura
  }
});
app.mount('#app');
