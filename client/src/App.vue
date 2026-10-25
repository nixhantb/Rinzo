<template>
  <v-app>
    <v-app-bar color="surface" border="b" class="px-4">
      <router-link to="/" class="text-decoration-none">
        <span class="text-h6 font-weight-bold text-primary">Rinzo</span>
      </router-link>
    </v-app-bar>

    <v-main>
      <router-view />
    </v-main>
  </v-app>
</template>
