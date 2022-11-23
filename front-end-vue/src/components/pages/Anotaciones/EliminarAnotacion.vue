<template>
    <h1>Eliminar Amotación</h1>
    
    <h3>¿Desea Eliminar esta anotación?</h3>
    <p v-if="anotacion == null">Aún no carga</p>
    <div v-if="anotacion != null">
        <h4>Anotación</h4>
        <hr />
        <dl class="row">
            <dt class="col-sm-2">
                Id
            </dt>
            <dd class="col-sm-10">
                {{anotacion.id}}
            </dd>
            <dt class="col-sm-2">
                Tipo
            </dt>
            <dd class="col-sm-10">
                {{anotacion.tipo}}
            </dd>
            <dt class="col-sm-2">
                Fecha Emisión
            </dt>
            <dd class="col-sm-10">
                {{anotacion.fechaEmision}}
            </dd>
            <dt class="col-sm-2">
                Descripción
            </dt>
            <dd class="col-sm-10">
                {{anotacion.descripcion}}
            </dd>
            <dt class="col-sm-2">
                Estudiante
            </dt>
            <dd v-if="estudiante != null" class="col-sm-10">
                {{obtenerNombreApellidoEstudiante(anotacion.estudianteId)}}
            </dd>
        </dl>
    
        <form asp-action="VueDelete">

            <div class="btn-group">
                <button v-on:click="eliminarAnotacion()" class="btn btn-danger btn-lg" type="button">Eliminar</button>
                <a v-bind:href="'/Anotacions/VueIndex/'" class="btn btn-primary btn-lg">Volver a la Lista</a>
            </div>
        </form>
    </div>

</template>



<script>
    import axios from 'axios'

    const url_estudiantes = "https://localhost:7073/api/EstudiantesAPI"
    const url_anotaciones = "https://localhost:7073/api/AnotacionsAPI"

    export default {
        name: "indice",
        data() {
            return {
                anotacion: null,
                estudiante: null
            }
        },
        methods: {
            
            obtenerAnotacion() {
                axios.get(url_anotaciones + "/" + this.$route.params.id).then(response => {
                    console.log(response);
                    this.anotacion = response.data;
                    this.estudiante = this.obtenerEstudiante(this.anotacion.estudianteId);
                }).catch(error => console.log(error))
            },
            obtenerNombreApellidoEstudiante(id) {
                var strNombreApellido = this.estudiante.nombre + " " + this.estudiante.apellido;
                return strNombreApellido;
            },
            obtenerEstudiante(index) {
                axios.get(url_estudiantes + "/" + index).then(response => {
                    console.log(response);
                    this.estudiante = response.data;
                }).catch(error => console.log(error))
            },
            eliminarAnotacion() {
                axios.delete(url_anotaciones + "/" + this.anotacion.id).then( response => {
                    console.log(response);
                    window.location.href = "/Anotaciones/"
                }).catch( error => console.log(error))
            }
        },
        created: function () {
            this.obtenerAnotacion();
        }
    }
</script>