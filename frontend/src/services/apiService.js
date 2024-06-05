// src/services/apiService.js
import axios from 'axios';

const API_URL = 'https://localhost:7087/api';

export const getOrders = async () => {
  try {
    const response = await axios.get(`${API_URL}/orders`);
    return response.data;
  } catch (error) {
    console.error('Error fetching orders', error);
    throw error;
  }
};

export const getOrderById = async (id) => {
  try {
    const response = await axios.get(`${API_URL}/orders/${id}`);
    return response.data;
  } catch (error) {
    console.error('Error fetching order', error);
    throw error;
  }
};

export const createOrder = async (order) => {
  try {
    const response = await axios.post(`${API_URL}/orders`, order);
    return response.data;
  } catch (error) {
    console.error('Error creating order', error);
    throw error;
  }
};

export const cancelOrder = async (id) => {
  try {
    await axios.delete(`${API_URL}/orders/cancel/${id}`);
  } catch (error) {
    console.error('Error canceling order', error);
    throw error;
  }
};

export const getOffers = async () => {
  try {
    const response = await axios.get(`${API_URL}/offers`);
    return response.data;
  } catch (error) {
    console.error('Error fetching offers', error);
    throw error;
  }
};

export const getOfferById = async (id) => {
  try {
    const response = await axios.get(`${API_URL}/offers/${id}`);
    return response.data;
  } catch (error) {
    console.error('Error fetching offer', error);
    throw error;
  }
};

export const createOffer = async (offer) => {
  try {
    const response = await axios.post(`${API_URL}/offers`, offer);
    return response.data;
  } catch (error) {
    console.error('Error creating offer', error);
    throw error;
  }
};

export const deleteOffer = async (id) => {
  try {
    await axios.delete(`${API_URL}/offers/${id}`);
  } catch (error) {
    console.error('Error deleting offer', error);
    throw error;
  }
};
