<template>
    <h1>Índice de Estudiantes</h1>
    
    <div v-if="estudiantes.length > 0" class="btn-group">
        <a href="/Estudiantes/Crear" class="btn btn-primary active" aria-current="page">Crear</a>
    </div>
    <h5 v-if="estudiantes.length == 0">Cargando listado de estudiantes</h5>
    <table v-if="estudiantes.length > 0" class="table">
        <thead>
            <tr>
                <th>
                    Rut
                </th>
                <th>
                    Nombre
                </th>
                <th>
                    Apellido
                </th>

                <th></th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="estudiante in estudiantes">
                <td>
                    {{estudiante.rut}}
                </td>
                <td>
                    {{estudiante.nombre}}
                </td>
                <td>
                    {{estudiante.apellido}}
                </td>

                <td>
                    <div class="btn-group">
                        <a v-bind:href="'/Estudiantes/Edit/'+ estudiante.id " class="btn btn-primary active" aria-current="page">Editar</a>
                        <a v-bind:href="'/Estudiantes/'+ estudiante.id " class="btn btn-primary">Ver</a>
                        <a v-bind:href="'/Estudiantes/Eliminar/'+ estudiante.id " class="btn btn-primary">Eliminar</a>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
</template>

<script>
    import axios from 'axios'

    const url_estudiantes = "https://localhost:7073/api/EstudiantesAPI"

    export default {
        name: "indice",
        data() {
            return {
                estudiantes: []
            }
        },
        methods: {
            obtenerEstudiantes() {
                axios.get(url_estudiantes).then(response => {
                    console.log(response);
                    this.estudiantes = response.data;
                }).catch(error => console.log(error))
            }
        },
        created: function () {
            this.obtenerEstudiantes();
        }
    }
</script>