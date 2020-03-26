<template>
    <v-app id="inspire">
        <v-navigation-drawer
            v-model="drawer"
            app
            clipped
        >
            <v-list :ref="'menuItem' + route.name" v-for="(route, index) in routes" :key="index" dense>
                <v-list-item link :to="route.path">
                    <v-list-item-action>
                        <v-icon>{{route.icon}}</v-icon>
                    </v-list-item-action>
                    <v-list-item-content>
                        <v-list-item-title>{{route.name}}</v-list-item-title>
                    </v-list-item-content>
                </v-list-item>
            </v-list>
        </v-navigation-drawer>

    <v-app-bar
        app
        color="indigo"
        dark
        clipped-left
    >
        <v-app-bar-nav-icon @click.stop="drawer = !drawer" />
            <v-toolbar-title>Earth Observatory Natural Events Tracker - Sample</v-toolbar-title>
        </v-app-bar>

        <v-content>
            <router-view @redirectPage='RedirectPage'></router-view>
        </v-content>

        <v-footer app>
            <span>go@gabrielochoa.me</span>
        </v-footer> 
    </v-app>
</template>

<script>
  export default {
    props: {
      source: String,
    },
    data: () => ({
      drawer: null,
    }),
    methods: {
        RedirectPage(route) {
            this.Redirect(route);
        },
        Redirect(route) {
            this.$router.push(route); 
        },
    },
    computed: {
        routes() {
            return this.$router.options.routes.filter(r => r.name == "Application")[0].children.filter(r => r.isMenuAcess);
        }
    }
  }
</script>