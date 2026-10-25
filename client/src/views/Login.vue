<template>
  <v-container class="d-flex align-center justify-center" style="min-height: 85vh">
    <v-card class="pa-8" width="380" elevation="2">
      <v-card-title class="text-center text-h5 font-weight-bold pb-2">Log in</v-card-title>

      <v-form @submit.prevent="login">
        <v-text-field v-model="username" label="Username" class="mt-4" />
        <v-text-field v-model="password" label="Password" type="password" />

        <v-alert v-if="error" type="error" density="compact" variant="tonal" class="mb-4">
          {{ error }}
        </v-alert>

        <v-btn type="submit" color="primary" block size="large">Log in</v-btn>
        <v-btn variant="text" block class="mt-2" disabled>Sign up (coming soon)</v-btn>
      </v-form>
    </v-card>
  </v-container>
</template>

<script setup>
import { ref } from 'vue'
import { useRouter } from 'vue-router'

const username = ref('')
const password = ref('')
const error = ref('')
const router = useRouter()

function login() {
  if (username.value === 'guest' && password.value === 'guest') {
    router.push('/welcome')
  } else {
    error.value = 'Try guest / guest for now.'
  }
}
</script>
