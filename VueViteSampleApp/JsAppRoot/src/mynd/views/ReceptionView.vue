<script setup>
import {ref} from 'vue';
import {API_BASE} from "@/common/lib/consts.js";

let summaryData  = ref({});

function doFetch(){
  fetch(`${API_BASE}/api/mynd/client/getlite`)
      .then((res) => res.json())
      .then((json) => {
        summaryData.value = json;
      });
}
</script>

<template>
  <main>
    <div class="grid flex flex-wrap">
      <h1>Reception View from Vue</h1>
      <button @click="doFetch">Sample Fetch Data from API</button>
      <div style="padding: 10px; border: 1px solid grey" v-if="summaryData.clientName">
        <h2>API data:</h2>
        <p>UserName: {{summaryData.clientName}} ID: {{summaryData.id}}</p>
      </div>
      <p>API is working, as is Vue routing.</p>
      <p>However the problem is that 404 pages are not served by ASP.NET, rather they are passed to Vite which serves Vite's index.html</p>
      <p><a href="/foo/bar/">This should show the ASP.Net ErrorDev page</a> as defined in program.cs, but it shows the Vite index.html instead.</p>
      <p>I believe this is because the Vite middleware is slurping everything that isn't an explicit route and trying to serve it as a Vite asset.</p>
      <p>The evidence for this belief is that when I change <code>app.UseViteDevelopmentServer(true);</code> to be <code>app.UseViteDevelopmentServer(false);</code> and visit a bad URL, the 404 pages display as expected
      but a consequence is that Vite assets are no longer served.</p>
      <p>Ideally, we'd configure Vite to serve static assets under a subdirectory rather than root, which would make it clear when something should be passed to vite and when not. Or, instead of proxying
      requests through the listening ASP.NET kestrel server (https://localhost:7251), load the assets directly from the vite dev server (http://localhost:5173).</p>
      <p><a href="https://vitejs.dev/config/build-options.html#build-assetsdir">There is an 'assetsDir'</a> config value for Vite. But it appears that Vite <a href="https://vitejs.dev/guide/assets.html#the-public-directory">only uses 'assetDir'</a> for production builds.</p>
      <p></p>
      
    </div>
  </main>
</template>
