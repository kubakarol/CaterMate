<!-- src/views/PlaceOrder.vue -->
<template>
    <order-form :offerId="$route.params.id"></order-form>
  </template>
  
  <script>
  import OrderForm from '@/components/OrderForm.vue';
  
  export default {
    name: 'PlaceOrder',
    components: {
      OrderForm
    }
  };
  </script>
  