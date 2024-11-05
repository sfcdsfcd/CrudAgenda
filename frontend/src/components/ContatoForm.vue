<template>
  <section class="container mx-auto p-6 shadow rounded-lg">
    <h1 class="text-2xl font-semibold mb-6">{{ isEdit ? 'Editar Contato' : 'Adicionar Contato' }}</h1>
    <form @submit.prevent="saveContato" class="mt-4">
      <div class="p-field flex items-center mb-4">
        <label for="nome" class="w-32">Nome:</label>
        <InputText v-model="contato.nome" id="nome" class="flex-1" required />
      </div>
      <div class="p-field flex items-center mb-4">
        <label for="email" class="w-32">Email:</label>
        <InputText v-model="contato.email" id="email" class="flex-1" required />
      </div>
      <div class="p-field flex items-center mb-4">
        <label for="telefone" class="w-32">Telefone:</label>
        <InputText v-model="contato.telefone" id="telefone" class="flex-1" required />
      </div>
      <Button label="Salvar" icon="pi pi-check" class="p-button-primary w-full" type="submit" />
    </form>
  </section>
</template>

<script>
import InputText from 'primevue/inputtext';
import Button from 'primevue/button';
import api from '../utils/api';

export default {
  name: 'ContatoForm',
  props: ['id'],
  components: {
    InputText,
    Button
  },
  data() {
    return {
      contato: {
        nome: '',
        email: '',
        telefone: ''
      },
      isEdit: false
    };
  },
  async created() {
    if (this.id) {
      this.isEdit = true;
      await this.fetchContato();
    }
  },
  methods: {
    async fetchContato() {
      try {
        const response = await api.get(`/contatos/${this.id}`);
        this.contato = response.data;
      } catch (error) {
        console.error("Erro ao buscar contato:", error);
      }
    },
    async saveContato() {
      try {
        if (this.isEdit) {
          await api.put(`/contatos/${this.id}`, this.contato);
        } else {
          await api.post('/contatos', this.contato);
        }
        this.$router.push('/contatos');
      } catch (error) {
        if (error.response && error.response.data) {
          const validationErrors = error.response.data;
          const errorMessages = validationErrors.map(err => `${err.propertyName}: ${err.errorMessage}`).join('\n');
          alert(`Erro ao salvar contato:\n${errorMessages}`);
        } else {
          alert('Erro ao salvar contato.');
        }
      }
    }
  }
};
</script>

<style scoped>
.container {
  max-width: 800px;
}
</style>