<template>
  <v-container class="d-flex flex-column justify-center mx-auto py-16" style="min-height: 85vh" max-width="760">
    <div class="text-center mb-12">
      <h1 class="text-h2 font-weight-bold">Rinzo</h1>
      <p class="text-h6 font-weight-regular text-medium-emphasis mt-3">
        A shared place for employers, employees, and companies.
      </p>
    </div>

    <v-row>
      <v-col v-for="group in groups" :key="group.title" cols="12" sm="4">
        <v-card class="pa-6 text-center h-100" elevation="1" hover>
          <v-icon :icon="group.icon" color="primary" size="36" class="mb-3" />
          <v-card-title class="text-subtitle-1 pa-0">{{ group.title }}</v-card-title>
          <v-card-text class="text-body-2 text-medium-emphasis pa-0 mt-1">
            {{ group.text }}
          </v-card-text>
          
        </v-card>
      </v-col>
    </v-row>

    <div class="text-center mt-12">
      <v-btn to="/login" color="primary" size="large" class="px-8">
        Log in / Sign up
      </v-btn>
    </div>
  </v-container>
</template>

<script setup>
const groups = [
  { title: 'For Employers', text: 'Post roles and manage applicants.', icon: 'mdi-briefcase-outline' },
  { title: 'For Employees', text: 'Find roles and track applications.', icon: 'mdi-account-outline' },
  { title: 'For Companies', text: 'Manage teams and hiring activity.', icon: 'mdi-domain' },
]
</script>
