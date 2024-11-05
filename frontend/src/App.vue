<template>
  <div>
    <Header />
    <RouterView />
  </div>
</template>

<script>
import { RouterView } from 'vue-router'
import Header from './components/Header.vue'

export default {
  components: {
    Header,
    RouterView
  }
};
</script>

<style scoped>
.custom-navbar {
  margin-bottom: 20px;
}
</style>