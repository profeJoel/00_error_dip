<template>
    <h1>Crear de Anotación</h1>
    
    <hr />
    <div class="row">
        <p v-if="estudiantes.length == 0">Aun no puede crear Anotación</p>
        <div v-if="estudiantes.length > 0" class="col-md-4">
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
                <br>
                <div class="btn-group">
                    <button v-on:click="agregarAnotacion()" class="btn btn-success btn-lg" type="button">Agregar</button>
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
                anotacion: {
                    id: 0,
                    tipo: '',
                    fechaEmision: new Date().toISOString().substr(0, 16),
                    descripcion: '',
                    estudianteId: '',
                    estudiante: null
                },
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
            agregarAnotacion() {
                this.anotacion.estudiante = this.estudiantes.find(e => e.id == this.anotacion.estudianteId);
                console.log(this.anotacion)
                console.log(this.anotacion.estudiante)
                axios.post(url_anotaciones, this.anotacion).then(response => {
                    console.log(response);
                    window.location.href = "/Anotaciones/";
                }).catch(error => console.log(error));
            }
        },
        created: function () {
            this.obtenerEstudiantes();
        }
    }
</script>