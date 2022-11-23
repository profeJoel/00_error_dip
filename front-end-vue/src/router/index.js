import { createRouter, createWebHistory } from "vue-router";

import Inicio from '../components/pages/Inicio.vue'
import IndiceAnotaciones from '../components/pages/Anotaciones/IndiceAnotaciones.vue'
import VerAnotacion from '../components/pages/Anotaciones/VerAnotacion.vue'
import CrearAnotacion from '../components/pages/Anotaciones/CrearAnotacion.vue'
import EditarAnotacion from '../components/pages/Anotaciones/EditarAnotacion.vue'
import EliminarAnotacion from '../components/pages/Anotaciones/EliminarAnotacion.vue'

import IndiceEstudiantes from '../components/pages/Estudiantes/IndiceEstudiantes.vue'
import VerEstudiante from '../components/pages/Estudiantes/VerEstudiante.vue'
import CrearEstudiante from '../components/pages/Estudiantes/CrearEstudiante.vue'
import EditarEstudiante from '../components/pages/Estudiantes/EditarEstudiante.vue'
import EliminarEstudiante from '../components/pages/Estudiantes/EliminarEstudiante.vue'

const routes = [
    {
        path: '/',
        component: Inicio
    },
    {
        path: '/Anotaciones',
        component: IndiceAnotaciones
    },
    {
        path: '/Anotaciones/:id',
        component: VerAnotacion
    },
    {
        path: '/Anotaciones/Crear',
        component: CrearAnotacion
    },
    {
        path: '/Anotaciones/Editar/:id',
        component: EditarAnotacion
    },
    {
        path: '/Anotaciones/Eliminar/:id',
        component: EliminarAnotacion
    },
    {
        path: '/Estudiantes',
        component: IndiceEstudiantes
    },
    {
        path: '/Estudiantes/:id',
        component: VerEstudiante
    },
    {
        path: '/Estudiantes/Crear',
        component: CrearEstudiante
    },
    {
        path: '/Estudiantes/Editar/:id',
        component: EditarEstudiante
    },
    {
        path: '/Estudiantes/Eliminar/:id',
        component: EliminarEstudiante
    }
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router
