<template>
  <div class="login-container">
    <h1 class="text-center">Login</h1>
    <form @submit.prevent="login" class="mt-4">
      <div class="p-field">
        <label for="username">Username:</label>
        <InputText v-model="username" id="username" required />
      </div>
      <div class="p-field">
        <label for="password">Password:</label>
        <Password v-model="password" id="password" required />
      </div>
      <Button label="Login" icon="pi pi-sign-in" class="p-button-primary w-100" type="submit" />
    </form>
    <p v-if="errorMessage" class="text-danger mt-3">{{ errorMessage }}</p>
  </div>
</template>

<script>
import api from '../utils/api';
import InputText from 'primevue/inputtext';
import Password from 'primevue/password';
import Button from 'primevue/button';

export default {
  name: 'LoginForm',
  data() {
    return {
      username: '',
      password: '',
      errorMessage: ''
    };
  },
  components: {
    InputText,
    Password,
    Button
  },
  methods: {
    async login() {
      try {
        const response = await api.post('/auth/login', {
          username: this.username,
          password: this.password
        });
        if (response.data.token) {
          localStorage.setItem('token', response.data.token);
          this.$emit('close');
        } else {
          this.errorMessage = 'Invalid username or password';
        }
      } catch (error) {
        this.errorMessage = 'Invalid username or password';
      }
    }
  }
};
</script>

<style scoped>
.login-container {
  max-width: 400px;
  margin: 0 auto;
  padding: 2rem;
  border: 1px solid #ccc;
  border-radius: 8px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
}
</style>