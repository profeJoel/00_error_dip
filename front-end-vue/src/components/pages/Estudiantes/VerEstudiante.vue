<template>
    <h1>Ver Estudiante</h1>

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
    </div>

    <div class="btn-group">
        <a v-if="estudiante != null" v-bind:href="'/Estudiantes/Editar/'+ estudiante.id " class="btn btn-primary active" aria-current="page">Editar</a>
        <a href="/Estudiantes/" class="btn btn-primary">Volver a la Lista</a>
    </div>
</template>


<script>
    import axios from 'axios'

    const url_estudiantes = "https://localhost:7073/api/EstudiantesAPI"

    export default {
        name: "ver",
        data() {
            return {
                estudiante: null
            }
        },
        methods: {
            obtenerEstudiante(index){
                axios.get(url_estudiantes + "/" + index).then(response => {
                    console.log(response);
                    this.estudiante = response.data;
                }).catch(error => console.log(error))
            },
            detalleEstudiante() {
                this.obtenerEstudiante(this.$route.params.id);
            },
            calcularEdad() {
                const edad = (new Date().getFullYear() - new Date(this.estudiante.fechaNacimiento).getFullYear());
                return edad;
            }
        },
        created: function () {
            this.detalleEstudiante()
        }
    }
</script>