<!-- src/components/OrderForm.vue -->
<template>
    <ion-page>
      <ion-header>
        <ion-toolbar>
          <ion-title>Place Order</ion-title>
        </ion-toolbar>
      </ion-header>
      <ion-content>
        <ion-list>
          <ion-item>
            <ion-label position="floating">Name</ion-label>
            <ion-input v-model="name" required></ion-input>
          </ion-item>
          <ion-item>
            <ion-label position="floating">Email</ion-label>
            <ion-input type="email" v-model="email" required></ion-input>
          </ion-item>
          <ion-item>
            <ion-label position="floating">Phone</ion-label>
            <ion-input type="tel" v-model="phone" required></ion-input>
          </ion-item>
          <ion-item>
            <ion-label position="floating">Date</ion-label>
            <ion-datetime v-model="date" display-format="MM/DD/YYYY"></ion-datetime>
          </ion-item>
        </ion-list>
        <ion-button expand="full" @click="submitOrder">Submit Order</ion-button>
      </ion-content>
    </ion-page>
  </template>
  
  <script>
  import { ref } from 'vue';
  import { createOrder } from '@/services/apiService';
  import { useRouter } from 'vue-router';
  
  export default {
    name: 'OrderForm',
    props: {
      offerId: String
    },
    setup(props) {
      const router = useRouter();
      const name = ref('');
      const email = ref('');
      const phone = ref('');
      const date = ref('');
  
      const submitOrder = async () => {
        try {
          const order = {
            offerId: props.offerId,
            name: name.value,
            email: email.value,
            phone: phone.value,
            date: date.value
          };
          await createOrder(order);
          alert('Order placed successfully!');
          router.push('/');
        } catch (error) {
          console.error('Error placing order', error);
          alert('Failed to place order.');
        }
      };
  
      return {
        name,
        email,
        phone,
        date,
        submitOrder
      };
    }
  };
  </script>
  
  <style scoped>
  ion-content {
    --padding: 20px;
  }
  </style>
  