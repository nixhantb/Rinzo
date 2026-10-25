import '@mdi/font/css/materialdesignicons.css'
import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'

export default createVuetify({
  components,
  directives,
  theme: {
    defaultTheme: 'light',
    themes: {
      light: {
        colors: {
          primary: '#1a73e8',
          background: '#f8f9fa',
          surface: '#ffffff',
        },
      },
    },
  },
  defaults: {
    VBtn: { rounded: 'pill', elevation: 0 },
    VCard: { rounded: 'lg' },
    VTextField: { variant: 'outlined', color: 'primary', density: 'comfortable' },
    VAppBar: { flat: true },
  },
})
