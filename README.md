# 🎬 Panacea Media Player (WPF)

Desktop application built with **C# (.NET Framework 4.8) and WPF** that consumes media content from a backend API and displays it in a user-friendly interface with playback capabilities.

---

## 📌 Overview

This project was developed as part of a technical assessment.

The goal was to:

- Consume media content from a backend API  
- Authenticate users  
- Display media streams and metadata  
- Provide a simple and clean UI  
- Handle errors gracefully  

---

## 🏗️ Tech Stack

- **C#**
- **.NET Framework 4.8**
- **WPF (Windows Presentation Foundation)**
- **HttpClient**
- **MVVM pattern**
- **Newtonsoft.Json**

---

## 🧩 Architecture

The project follows a simple **MVVM structure**:

- **Views** → UI (WPF Windows)
- **ViewModels** → Logic and state management
- **Services** → API communication
- **Models** → Data structures from API

---

## 🔐 Authentication Note

The API does not expose a direct REST authentication endpoint.

Authentication is handled through a **browser-based SSO (Single Sign-On) flow**, which relies on:

- form-based login  
- cookies  
- redirects  

Because of this, it is **not possible to authenticate directly from a WPF client using simple credentials (JSON request)**.

Proper implementation would require:

- handling cookies  
- managing session state  
- following redirect flows  

This is outside the intended scope and time constraints of this assessment.

---

## ⚠️ Current Behavior

- The application attempts to authenticate using the available endpoint  
- The backend responds with a **500 error (`Unknown authentication strategy "local"`)**, indicating a server-side configuration issue  
- The client handles this error gracefully and provides user feedback  

---

## 🧪 Demo Mode

To ensure the application flow can still be demonstrated, a **fallback demo mode** is implemented:

- If authentication fails, mock data is loaded  
- The user can still:
  - view media items  
  - select content  
  - play videos  

---

## 🎥 Features

- Login UI (WPF)
- API consumption using HttpClient
- Token-based header handling (Bearer)
- Media list display
- Video playback (MediaElement)
- Loading states and status messages
- Error handling and fallback behavior

---

## 🚀 How to Run

1. Open the solution in **Visual Studio**
2. Build the project
3. Run the application

---

## 📸 Screenshots

_Add screenshots here if needed_

---

## 🧠 Notes

This project focuses on demonstrating:

- Proper client-side architecture (MVVM)
- API integration
- Error handling
- Adaptability when backend limitations are present

---

## 👩‍💻 Author

**Anahí Lozano**  
Full Stack Developer  

---

# 🇲🇽 Versión en Español

## 📌 Descripción

Aplicación de escritorio desarrollada con **C# (.NET Framework 4.8) y WPF** que consume contenido multimedia desde una API y lo muestra en una interfaz amigable con capacidad de reproducción.

---

## 🎯 Objetivo

El objetivo de esta práctica fue:

- Consumir contenido desde un backend  
- Autenticar usuarios  
- Mostrar streams y metadatos  
- Crear una interfaz clara y funcional  
- Manejar errores correctamente  

---

## 🏗️ Tecnologías

- **C#**
- **.NET Framework 4.8**
- **WPF**
- **HttpClient**
- **Patrón MVVM**
- **Newtonsoft.Json**

---

## 🧩 Arquitectura

Se implementó una arquitectura basada en **MVVM**:

- **Views** → Interfaz de usuario  
- **ViewModels** → Lógica y estado  
- **Services** → Comunicación con la API  
- **Models** → Estructuras de datos  

---

## 🔐 Nota sobre autenticación

La API no expone un endpoint REST directo para autenticación.

El login funciona mediante un flujo **SSO (Single Sign-On) basado en navegador**, el cual utiliza:

- formularios  
- cookies  
- redirecciones  

Por esta razón, **no es posible autenticarse directamente desde una aplicación WPF usando credenciales simples**.

Para soportarlo correctamente sería necesario:

- manejar cookies  
- gestionar sesiones  
- seguir redirecciones  

Esto queda fuera del alcance y tiempo de la prueba.

---

## ⚠️ Comportamiento actual

- La aplicación intenta autenticarse contra el endpoint disponible  
- El backend responde con un error **500 (`Unknown authentication strategy "local"`)**  
- Se trata de un problema del servidor, no del cliente  
- La aplicación maneja el error correctamente y muestra un mensaje al usuario  

---

## 🧪 Modo demo

Para poder demostrar el funcionamiento completo:

- Se implementó un **modo demo**  
- Si el login falla, se cargan datos simulados  
- El usuario puede:
  - ver contenido  
  - seleccionar elementos  
  - reproducir videos  

---

## 🎥 Funcionalidades

- Pantalla de login  
- Consumo de API  
- Manejo de token (Bearer)  
- Listado de contenido  
- Reproducción de video  
- Estados de carga  
- Manejo de errores  

---

## 🚀 Ejecución

1. Abrir la solución en Visual Studio  
2. Compilar el proyecto  
3. Ejecutar la aplicación  

---

## 🧠 Notas

Este proyecto demuestra:

- Buen uso de arquitectura (MVVM)  
- Integración con API  
- Manejo de errores  
- Adaptación ante limitaciones del backend  
