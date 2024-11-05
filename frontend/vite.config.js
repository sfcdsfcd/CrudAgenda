import vue from '@vitejs/plugin-vue'
import dotenv from 'dotenv'
import { defineConfig } from 'vite'

dotenv.config({ path: '../.env' });

export default defineConfig({
  plugins: [vue()],
  server: {
    host: true,
    port: 5173, // Certifique-se de que a porta está correta
  },
  envDir: './',
  define: {
    'process.env': process.env
  }
});