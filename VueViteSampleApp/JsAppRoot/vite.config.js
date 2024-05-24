import { fileURLToPath, URL } from 'node:url';

import { defineConfig } from 'vite';
import vue from '@vitejs/plugin-vue';
import VueDevTools from 'vite-plugin-vue-devtools';

// The following enable auto-import of Vite components:
import Components from 'unplugin-vue-components/vite';
import {PrimeVueResolver} from 'unplugin-vue-components/resolvers';

// https://vitejs.dev/config/
export default defineConfig (({ command, mode, isSsrBuild, isPreview }) => {
    const commonConfig = {
      build: {
        outDir: '../../wwwroot/dist',
        assetsDir: '',
        emptyOutDir: true,
        manifest: true,
        rollupOptions: {
          input: {
            mynd: './src/mynd.js',
            client: './src/client.js'
          }
        },
      },
      server: {
        port: 5173,
        strictPort: true,
        hmr: {
          clientPort: 5173
        }
      },
      plugins: [
        vue(),
        VueDevTools(),
        Components({
          resolvers: [
            PrimeVueResolver()
          ]})
      ],
      resolve: {
        alias: {
          '@': fileURLToPath(new URL('./src', import.meta.url))
        }
      }
    };

    let envConfig = {};
    if (command === 'serve') { // configure dev, serve is an alias of 'dev'
      envConfig = {
//         api_root: 'https://localhost:7251/' 
      };
    } else if (command === 'build') {
      envConfig = {
      };
    }
    return Object.assign(commonConfig, envConfig);
  }
)
