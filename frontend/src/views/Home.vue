<!-- src/views/Home.vue -->
<template>
    <ion-page>
      <ion-header>
        <ion-toolbar>
          <ion-title>Home</ion-title>
        </ion-toolbar>
      </ion-header>
      <ion-content>
        <ion-list>
          <ion-item v-for="order in orders" :key="order.id">
            Order ID: {{ order.id }}, Order Name: {{ order.name }}
          </ion-item>
        </ion-list>
  
        <ion-list>
          <ion-item v-for="offer in offers" :key="offer.id">
            Offer ID: {{ offer.id }}, Offer Name: {{ offer.name }}
            <ion-button @click="placeOrder(offer.id)">Order Now</ion-button>
          </ion-item>
        </ion-list>
      </ion-content>
    </ion-page>
  </template>
  
  <script>
  import { ref, onMounted } from 'vue';
  import { getOrders, getOffers } from '@/services/apiService';
  import { useRouter } from 'vue-router';
  
  export default {
    name: 'Home',
    setup() {
      const orders = ref([]);
      const offers = ref([]);
      const router = useRouter();
  
      const loadOrders = async () => {
        try {
          orders.value = await getOrders();
        } catch (error) {
          console.error('Error loading orders', error);
        }
      };
  
      const loadOffers = async () => {
        try {
          offers.value = await getOffers();
        } catch (error) {
          console.error('Error loading offers', error);
        }
      };
  
      const placeOrder = (offerId) => {
        router.push(`/place-order/${offerId}`);
      };
  
      onMounted(() => {
        loadOrders();
        loadOffers();
      });
  
      return {
        orders,
        offers,
        placeOrder
      };
    }
  };
  </script>
  
  <style scoped>
  ion-content {
    --padding: 20px;
  }
  </style>
  