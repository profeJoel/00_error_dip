<template>
    <h1>Crear Estudiante</h1>

    <div class="row">
        <div class="col-md-4">
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
                    <button v-on:click="agregarEstudiante()" class="btn btn-success btn-lg" type="button">Agregar</button>
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
        name: "crear",
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
            agregarEstudiante() {
                console.log(this.estudiante)
                axios.post(url_estudiantes, this.estudiante).then(response => {
                    console.log(response);
                    window.location.href = "/Estudiantes/";
                }).catch(error => {
                    console.log(error)
                })
            }
        },
        created: function () {
        }
    }
</script>