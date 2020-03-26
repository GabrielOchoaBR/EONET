<template>
  <v-app>
    <router-view></router-view>
  </v-app>
</template>

<script>
export default {
  name: 'App'
}
</script>

<style>
  html,body{
      width: 100%;
      height: 100%;
      background: #f0f0f0;
  }
  #app{
    height: 100%;
  }
</style>
