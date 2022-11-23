<template>
    <ul class="nav nav-pills nav-fill" id="pills-tab" role="tablist">
        <li class="nav-item" role="presentation">
            <button class="nav-link" id="pills-home-tab" data-bs-toggle="pill" data-bs-target="#pills-home" type="button" role="tab" aria-controls="pills-home" aria-selected="true"><a class="nav-link" aria-current="page" href="/">Inicio</a></button>
        </li>
        <li class="nav-item" role="presentation">
            <button class="nav-link" id="pills-about-tab" data-bs-toggle="pill" data-bs-target="#pills-about" type="button" role="tab" aria-controls="pills-about" aria-selected="false"><a class="nav-link" href="/Estudiantes">Estudiantes</a></button>
        </li>
        <li class="nav-item" role="presentation">
            <button class="nav-link" id="pills-contact-tab" data-bs-toggle="pill" data-bs-target="#pills-contact" type="button" role="tab" aria-controls="pills-contact" aria-selected="false"><a class="nav-link" href="/Anotaciones">Anotaciones</a></button>
        </li>
    </ul>
    <br>
    <router-view />
</template>