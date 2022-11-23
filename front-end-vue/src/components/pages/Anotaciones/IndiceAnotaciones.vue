<template>
    <h1>Índice de Anotaciones</h1>
    
    <div class="btn-group">
        <a href="/Anotaciones/Crear" class="btn btn-primary active" aria-current="page">Crear</a>
    </div>
    <table class="table">
        <thead>
            <tr>
                <th>
                    Tipo
                </th>
                <th>
                    Fecha Emisión
                </th>
                <th>
                    Estudiante
                </th>
                <th></th>
            </tr>
        </thead>
        <tbody>
            <h5 v-if="anotaciones.length == 0">NO se encuentran Anotaciones registradas</h5>
            <tr v-if="anotaciones.length > 0 && estudiantes.length > 0" v-for="anotacion in anotaciones">
                <td>
                    {{anotacion.tipo}}
                </td>
                <td>
                    {{anotacion.fechaEmision}}
                </td>
                <td>
                    {{obtenerNombreApellidoEstudiante(anotacion.estudianteId)}}
                </td>
                <td>
                    <div class="btn-group">
                        <a v-bind:href="'/Anotaciones/Editar/'+ anotacion.id " class="btn btn-primary active" aria-current="page">Editar</a>
                        <a v-bind:href="'/Anotaciones/'+ anotacion.id " class="btn btn-primary">Ver</a>
                        <a v-bind:href="'/Anotaciones/Eliminar/'+ anotacion.id " class="btn btn-primary">Eliminar</a>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
</template>

<script>
    import axios from 'axios'

    const url_estudiantes = "https://localhost:7073/api/EstudiantesAPI"
    const url_anotaciones = "https://localhost:7073/api/AnotacionsAPI"

    export default {
        name: "indice",
        data() {
            return {
                estudiantes: [],
                anotaciones: []
            }
        },
        methods: {
            obtenerAnotaciones() {
                axios.get(url_anotaciones).then(response => {
                    console.log(response);
                    this.anotaciones = response.data;
                }).catch(error => console.log(error))
            },
            obtenerEstudiantes() {
                axios.get(url_estudiantes).then(response => {
                    console.log(response);
                    this.estudiantes = response.data;
                }).catch(error => console.log(error))
            },
            obtenerNombreApellidoEstudiante(id) {
                var estudiante = this.estudiantes.find(e => e.id == id);
                var strNombreApellido = estudiante.nombre + " " + estudiante.apellido;
                return strNombreApellido;
            }
        },
        created: function () {
            this.obtenerEstudiantes();
            this.obtenerAnotaciones();
        }
    }
</script>