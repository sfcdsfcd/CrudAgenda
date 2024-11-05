<template>
  <div class="text-center">
    <h1 class="mt-5">Bem-vindo à Agenda</h1>
    <p class="lead">Gerencie seus contatos de forma fácil e rápida.</p>
    <Button label="Ver Contatos" icon="pi pi-users" class="p-button-primary" @click="$router.push('/contatos')" />
  </div>
</template>

<script>
import Button from 'primevue/button';

export default {
  name: 'Home',
  components: {
    Button
  }
};
</script>