/*
 *  Client UI Boot
 *  ---------------
 *  Authored: 26/04/24
 * 
 *  Configure and start the client UI here after login hands it off to Vue.Js
 */

import { createApp } from 'vue';
import { createRouter, createWebHistory } from 'vue-router';
import ClientMain from './ClientMain.vue';
import Consts from '@/common/lib/consts.js'
import 'vite/modulepreload-polyfill';

const client = createApp(ClientMain);

// Set routing.
client.use( createRouter({
        history: createWebHistory(Consts.CLIENT_BASE_PATH),
        routes: [
            {
                path: '/',
                name: 'home',
//                component: HomeView
            },
            {
                path: '/about',
                name: 'about',
                // route level code-splitting - this generates a separate chunk (About.[hash].js) for this route
                // which is lazy-loaded when the route is visited.
//                component: () => import('/views/AboutView.vue')
            }
        ]
    })
);

// Inject it into the template that was served by Asp.Net
client.mount('#app');
