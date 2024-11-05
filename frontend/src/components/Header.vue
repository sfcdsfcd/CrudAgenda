<template>
  <header>
    <div class="bg-black shadow-md">
      <div class="container mx-auto px-4 py-2 flex justify-between items-center">
        <div class="flex items-center">
          <img alt="Logo" class="h-8 mr-4" />
          <Menubar :model="menuItems">
            <template #item="{ item, props, hasSubmenu }">
              <router-link v-if="item.route" v-slot="{ href, navigate }" :to="item.route" custom>
                <a :href="href" v-bind="props.action" @click="navigate">
                  <span :class="item.icon" />
                  <span>{{ item.label }}</span>
                </a>
              </router-link>
              <a v-else :href="item.url" :target="item.target" v-bind="props.action">
                <span :class="item.icon" />
                <span>{{ item.label }}</span>
                <span v-if="hasSubmenu" class="pi pi-fw pi-angle-down" />
              </a>
            </template>
          </Menubar>
        </div>
        <div>
          <Button v-if="!isAuthenticated" label="Login" icon="pi pi-sign-in"
            class="p-button-rounded p-button-outlined p-button-primary" @click="showLoginModal = true" />
          <Button v-else label="Logout" icon="pi pi-sign-out" class="p-button-rounded p-button-outlined p-button-danger"
            @click="logout" />
        </div>
      </div>
    </div>
    <Dialog header="Login" v-model:visible="showLoginModal" :modal="true" :closable="true">
      <LoginForm @close="handleLogin" />
    </Dialog>
  </header>
</template>

<script>
import { ref, onMounted } from 'vue';
import Button from 'primevue/button';
import Menubar from 'primevue/menubar';
import Dialog from 'primevue/dialog';
import LoginForm from './LoginForm.vue';

export default {
  components: {
    Menubar,
    Button,
    Dialog,
    LoginForm
  },
  setup() {
    const showLoginModal = ref(false);
    const isAuthenticated = ref(false);

    const checkAuth = () => {
      isAuthenticated.value = !!localStorage.getItem('token');
    };

    onMounted(() => {
      checkAuth();
    });

    const handleLogin = () => {
      showLoginModal.value = false;
      checkAuth();
    };

    const logout = () => {
      localStorage.removeItem('token');
      isAuthenticated.value = false;
      window.location.reload();
    };

    return {
      showLoginModal,
      isAuthenticated,
      logout,
      handleLogin
    };
  },
  data() {
    return {
      menuItems: [
        { label: 'Home', icon: 'pi pi-fw pi-home', route: '/' },
        { label: 'Contatos', icon: 'pi pi-fw pi-users', route: '/contatos' },
      ]
    };
  }
};
</script>

<style scoped>
.menubar .p-menubar-root-list {
  display: flex;
  gap: 1rem;
}
.menubar .p-menubar-root-list>li>a {
  color: #4a5568; /* Tailwind CSS gray-800 */
  text-decoration: none;
}
.menubar .p-menubar-root-list>li>a:hover {
  text-decoration: underline;
}
</style>