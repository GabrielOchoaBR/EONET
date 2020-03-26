import Vue from 'vue'
import Router from 'vue-router'

import Application from '../components/ApplicationPage.vue'
import EventsPage from '../components/EventsPage.vue'
import EventDetailPage from '../components/EventDetailPage.vue'

Vue.use(Router);

export default new Router({
    routes: [
        {
            path: '/',
            name: 'Application',
            title: 'EONET - Earth Observatory Natural Events Tracker',
            component: Application,
            children: [
                {
                    path: '/EventsTracker',
                    name: 'Events',
                    icon: 'mdi-weather-lightning',
                    titleMenu: 'Events Tracker',
                    title: 'Events Tracker',
                    component: EventsPage,
                    isMenuAcess: true,
                },
                {
                    path: '/EventsTracker/:id',
                    name: 'EventDetails',
                    title: 'Event Details',
                    component: EventDetailPage,
                }
            ]
        }
    ]
});