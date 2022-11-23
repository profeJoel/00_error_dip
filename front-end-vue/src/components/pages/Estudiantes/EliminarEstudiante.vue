<template>
    <h1>Eliminar Estudiante</h1>
    
    <h3>¿Desea eliminar este Estudiante?</h3>
    <div>
        <h4>Estudiante</h4>
        <hr />
        <dl v-if="estudiante!=null" class="row">
            <dt class="col-sm-2">Rut</dt>
            <dd class="col-sm-10">
                {{estudiante.rut}}
            </dd>
            <dt class="col-sm-2">Nombre</dt>
            <dd class="col-sm-10">
                {{estudiante.nombre}}
            </dd>
            <dt class="col-sm-2">Apellido</dt>
            <dd class="col-sm-10">
                {{estudiante.apellido}}
            </dd>
            <dt class="col-sm-2">Fecha de Nacimiento</dt>
            <dd class="col-sm-10">
                {{estudiante.fechaNacimiento}}
            </dd>
            <dt class="col-sm-2">
                Edad
            </dt>
            <dd class="col-sm-10">
                {{this.calcularEdad()}}
            </dd>
            <dt class="col-sm-2">Domicilio</dt>
            <dd class="col-sm-10">
                {{estudiante.domicilio}}
            </dd>
        </dl>

        <form asp-action="Delete">

            <div class="btn-group">
                <button v-on:click="eliminarEstudiante()" class="btn btn-danger btn-lg" type="button">Eliminar</button>
                <a v-bind:href="'/Estudiantes/'" class="btn btn-primary btn-lg">Volver a la Lista</a>
            </div>
        </form>

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
            },
            calcularEdad() {
                const edad = (new Date().getFullYear() - new Date(this.estudiante.fechaNacimiento).getFullYear());
                return edad;
            },
            eliminarEstudiante() {
                axios.delete(url_estudiantes + "/" + this.estudiante.id).then(response => {
                    console.log(response);
                    window.location.href = "/Estudiantes/";
                }).catch(error => console.log(error))
            }
        },
        created: function () {
            this.obtenerEstudiante();
        }
    }
</script>