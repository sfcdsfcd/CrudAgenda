import ContatoForm from '../components/ContatoForm.vue'
import ContatoList from '../components/ContatoList.vue'

export default [
  {
    path: '/contatos',
    name: 'Contatos',
    component: ContatoList
  },
  {
    path: '/contatos/new',
    name: 'NovoContato',
    component: ContatoForm
  },
  {
    path: '/contatos/:id',
    name: 'EditarContato',
    component: ContatoForm,
    props: true
  }
];