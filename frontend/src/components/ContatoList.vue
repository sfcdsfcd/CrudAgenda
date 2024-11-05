<template>
  <section class="container mx-auto p-6 shadow rounded-lg">
    <h1 class="text-2xl font-semibold mb-6">Lista de Contatos</h1>
    <Button label="Adicionar Contato" icon="pi pi-plus" class="p-button-success mb-6" @click="$router.push('/contatos/new')" />
    <DataTable :value="contatos" class="p-datatable-gridlines p-datatable-striped" responsive-layout="scroll" :empty-message="'Nenhum contato encontrado'">
      <Column field="nome" header="Nome" sortable />
      <Column field="email" header="Email" sortable />
      <Column field="telefone" header="Telefone" sortable />
      <Column header="Ações" style="text-align: center;">
        <template #body="slotProps">
          <div class="flex justify-center space-x-2">
            <Button 
              icon="pi pi-pencil" 
              class="p-button-rounded p-button-primary" 
              @click="editContato(slotProps.data.id)" 
              aria-label="Editar"
            />
            <Button 
              icon="pi pi-trash" 
              class="p-button-rounded p-button-danger" 
              @click="deleteContato(slotProps.data.id)" 
              aria-label="Excluir"
            />
          </div>
        </template>
      </Column>
    </DataTable>
  </section>
</template>

<script>
import DataTable from 'primevue/datatable';
import Column from 'primevue/column';
import Button from 'primevue/button';
import api from '../utils/api';

export default {
  name: 'ContatoList',
  components: {
    DataTable,
    Column,
    Button
  },
  data() {
    return {
      contatos: [],
    }
  },
  async created() {
    await this.fetchContatos()
  },
  methods: {
    async fetchContatos() {
      try {
        const response = await api.get('/contatos');
        this.contatos = response.data;
      } catch (error) {
        console.error("Erro ao buscar contatos:", error);
      }
    },
    async deleteContato(id) {
      try {
        await api.delete(`/contatos/${id}`);
        this.fetchContatos();
      } catch (error) {
        console.error("Erro ao deletar contato:", error);
      }
    },
    editContato(id) {
      this.$router.push(`/contatos/${id}`)
    }
  }
}
</script>

<style scoped>
.container {
  max-width: 800px;
}
</style>