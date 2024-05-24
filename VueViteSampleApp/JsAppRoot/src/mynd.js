/*
 *  MyNd UI Boot
 *  ---------------
 *  Authored: 26/04/24
 * 
 *  Configure and start the myND UI here after login hands it off to Vue.Js
 */

import 'vite/modulepreload-polyfill';
import { nextTick, createApp } from 'vue';
import { createRouter, createWebHistory } from "vue-router";

import Consts from '@/common/lib/consts.js';
import ReceptionView from "@/mynd/views/ReceptionView.vue";
import AboutView from "@/mynd/views/About.vue";
import MyNDMain from '@/MyNDMain.vue';

// TODO: Decide whether any of the theme should be imported in the cshtml, what are the tradeoffs
// Import global style including PrimeVue/Poseidon
import '@/common/assets/styles.scss';


// Assign Logo to be used by common AppTopbar
Consts.APP_LOGO = Consts.LOGO_MYND;


const myNd = createApp(MyNDMain);

// Routing. Don't forget to append the new routes to MyNDMenu if appropriate.
const router = createRouter({
        history: createWebHistory(Consts.MYND_BASE_PATH),
        routes: [
            // RECEPTION
            {
                path: '/',
                name: 'reception',
                component: ReceptionView,
                meta: {
                    breadcrumb: [{label: 'Reception'}],
                    title: 'Reception'
                }
            },
            {
                path: '/about',
                name: 'about',
                component: AboutView,
                meta: {
                }
            },
        ]
    });

myNd.use(router);

console.log('New UI booting. MyND mode.');

// Inject it into the template that was served by Asp.Net
myNd.mount('#app');