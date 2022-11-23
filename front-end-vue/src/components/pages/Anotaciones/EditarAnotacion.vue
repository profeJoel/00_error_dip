<template>
    <h1>Editar de Anotación</h1>
    
    <hr />
    <div class="row">
        <p v-if="anotacion == null">Aun no puede crear Anotación</p>
        <div v-if="anotacion != null" class="col-md-4">
            <form name="VueCreate">
                <div class="form-group">
                    <label for="Tipo" class="control-label">Tipo</label>
                    <select v-model="anotacion.tipo" class="form-control">
                        <option disabled value="">Selecciona un tipo de anotación</option>
                        <option value="positiva">Positiva</option>
                        <option value="negativa">Negativa</option>
                    </select>
                </div>
                <div class="form-group">
                    <label for="FechaEmision" class="control-label">Fecha de Emisión</label>
                    <input v-model="anotacion.fechaEmision" class="form-control" type="datetime-local" />

                </div>
                <div class="form-group">
                    <label for="Descripcion" class="control-label">Descripción</label>
                    <textarea v-model="anotacion.descripcion" class="form-control" rows="3"></textarea>
                </div>
                <div class="form-group">
                    <label for="EstudianteId" class="control-label">Estudiante</label>
                    <label v-if="estudiante != null" class="control-label">{{estudiante.nombre}} {{estudiante.apellido}}</label>
                    <select v-model="anotacion.estudianteId" class="form-control">
                        <option disabled value="">Selecciona un estudiante</option>
                        <option v-for="e in estudiantes" :value="e.id">{{e.nombre}} {{e.apellido}}</option>
                    </select>
                </div>
                <div class="btn-group">
                    <button v-on:click="actualizarAnotacion()" class="btn btn-success btn-lg" type="button">Actualizar</button>
                    <a href="/Anotaciones/" class="btn btn-primary btn-lg">Volver a la Lista</a>
                </div>
            </form>
        </div>
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
                estudiantes: [],
                anotacion: null,
                estudiante: null
            }
        },
        methods: {
            obtenerEstudiantes() {
                axios.get(url_estudiantes).then(response => {
                    console.log(response);
                    this.estudiantes = response.data;
                }).catch(error => console.log(error))
            },
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
            actualizarAnotacion() {
                axios.put(url_anotaciones + "/" + this.anotacion.id, this.anotacion).then( response => {
                    console.log(response);
                    window.location.href = "/Anotaciones/";
                }).catch( error => console.log(error))
            }
        },
        created: function () {
            this.obtenerAnotacion();
            this.obtenerEstudiantes();
        }
    }
</script>