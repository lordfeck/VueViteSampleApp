<script setup>
import { computed, watch, ref, onBeforeUnmount, onMounted } from 'vue';
import MyNDSidebar from './MyNDSidebar.vue';
//import AppRightMenu from '@/common/components/layout/AppRightMenu.vue';

const outsideClickListener = ref(null);
const sidebarRef = ref(null);

onBeforeUnmount(() => {
});

onMounted(() => {
});

const bindOutsideClickListener = () => {
    if (!outsideClickListener.value) {
        outsideClickListener.value = (event) => {
        };
        document.addEventListener('click', outsideClickListener.value);
    }
};
</script>

<template>
    <div>
      <router-link :to="{ name: 'reception' }">Home</router-link> <router-link :to="{ name: 'about'}">About</router-link>
    </div>
        <div class="layout-content-wrapper">
            <div class="layout-content">
                <router-view />
            </div>
        </div>
</template>
