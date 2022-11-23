<template>
    <h1>Editar Estudiante</h1>
    
    <div class="row">
        <div v-if="estudiante!=null" class="col-md-4">
            <form name="Create">
                <div class="form-group">
                    <label for="Rut" class="control-label">Rut</label>
                    <input v-model="estudiante.rut" class="form-control" />
                </div>
                <div class="form-group">
                    <label for="Nombre" class="control-label">Nombre</label>
                    <input v-model="estudiante.nombre" class="form-control" />
                </div>
                <div class="form-group">
                    <label for="Apellido" class="control-label">Apellido</label>
                    <input v-model="estudiante.apellido" class="form-control" />
                </div>
                <div class="form-group">
                    <label for="FechaNacimiento" class="control-label">Fecha de Nacimiento</label>
                    <input v-model="estudiante.fechaNacimiento" class="form-control" type="datetime-local" />
                </div>
                <div class="form-group">
                    <label for="Domicilio" class="control-label">Domicilio</label>
                    <input v-model="estudiante.domicilio" class="form-control" />
                </div>

                <br />
                <div class="btn-group">
                    <button v-on:click="actualizarEstudiante()" class="btn btn-success btn-lg" type="button">Actualizar</button>
                    <a href="/Estudiantes/" class="btn btn-primary btn-lg">Volver a la Lista</a>
                </div>
            </form>
        </div>
    </div>
</template>


<script>
    import axios from 'axios'

    const url_estudiantes = "https://localhost:7073/api/EstudiantesAPI"

    export default {
        name: "editar",
        data() {
            return {
                estudiante: {
                    id:0,
                    nombre:'',
                    apellido:'',
                    fechaNacimiento:'',
                    domicilio:''
                }
            }
        },
        methods: {
            actualizarEstudiante() {

                axios.put(url_estudiantes + "/" + this.estudiante.id, this.estudiante).then(response => {
                    console.log(response);
                    window.location.href = "/Estudiantes/";
                }).catch(error => {
                    console.log(error)
                })
            },
            obtenerEstudiante() {
                axios.get(url_estudiantes + "/" + this.$route.params.id).then(response => {
                    console.log(response);
                    this.estudiante = response.data;
                }).catch(error => console.log(error))
            }
        },
        created: function () {
            this.obtenerEstudiante();
        }
    }
</script>