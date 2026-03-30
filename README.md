<h1 align="center">🎬 Panacea Media Player</h1>

<p align="center">
  <b>Desktop Media Player · WPF · .NET Framework</b><br/>
  <i>Reproductor multimedia de escritorio con arquitectura MVVM</i>
</p>

<p align="center">
  <img src="https://img.shields.io/badge/C%23-.NET%204.8-512BD4?style=for-the-badge&logo=csharp&logoColor=white"/>
  <img src="https://img.shields.io/badge/WPF-Desktop-blue?style=for-the-badge"/>
  <img src="https://img.shields.io/badge/MVVM-Architecture-black?style=for-the-badge"/>
  <img src="https://img.shields.io/badge/API-Integration-green?style=for-the-badge"/>
</p>

---

## 🧩 Description | Descripción

**EN 🇺🇸**  
Panacea Media Player is a desktop application built with **C# (.NET Framework 4.8) and WPF**, designed to consume media content from a backend API and display it through a clean and user-friendly interface.  

The project focuses on **client-side architecture, API integration, and resilient error handling**.

**ES 🇲🇽**  
Panacea Media Player es una aplicación de escritorio desarrollada con **C# (.NET Framework 4.8) y WPF**, diseñada para consumir contenido multimedia desde una API y mostrarlo en una interfaz clara y amigable.  

Se enfoca en **arquitectura cliente, integración con APIs y manejo robusto de errores**.

---

## 🎯 Problem | Problema

**EN 🇺🇸**  
Desktop clients consuming modern APIs face challenges such as:
- authentication mechanisms (SSO)  
- session handling  
- error resilience  

**ES 🇲🇽**  
Las aplicaciones de escritorio enfrentan retos al consumir APIs modernas como:
- autenticación SSO  
- manejo de sesiones  
- tolerancia a fallos  

---

## 💡 Solution | Solución

**EN 🇺🇸**  
The system implements a structured WPF client that:

👉 consumes API data  
👉 handles authentication limitations  
👉 provides fallback behavior for usability  

**ES 🇲🇽**  
El sistema implementa un cliente estructurado que:

👉 consume datos de API  
👉 maneja limitaciones de autenticación  
👉 ofrece comportamiento alterno (fallback)  

---

## ⚙️ Stack

- C#  
- .NET Framework 4.8  
- WPF  
- MVVM  
- HttpClient  
- Newtonsoft.Json  

---

## ✨ Features | Funcionalidades

**EN 🇺🇸**
- Login interface  
- API consumption  
- Media listing  
- Video playback  
- Error handling  
- Demo fallback mode  

**ES 🇲🇽**
- Interfaz de login  
- Consumo de API  
- Listado de contenido  
- Reproducción de video  
- Manejo de errores  
- Modo demo  

---

## 🧠 Architecture | Arquitectura

**MVVM (Model-View-ViewModel)**

**EN 🇺🇸**
- Views → UI  
- ViewModels → State & logic  
- Services → API communication  
- Models → Data mapping  

**ES 🇲🇽**
- Views → UI  
- ViewModels → lógica  
- Services → comunicación API  
- Models → datos  

---

## 🔐 Authentication Challenge | Reto de Autenticación

**EN 🇺🇸**  
The backend uses a **browser-based SSO authentication flow**, which depends on:

- cookies  
- redirects  
- session handling  

This makes direct authentication via WPF (JSON login) not viable.

**ES 🇲🇽**  
El backend utiliza autenticación **SSO basada en navegador**, dependiente de:

- cookies  
- redirecciones  
- sesiones  

Esto impide autenticación directa desde WPF.

---

## ⚠️ Current Behavior | Comportamiento Actual

**EN 🇺🇸**
- Authentication attempts return a server error  
- Error handled gracefully in UI  
- Feedback provided to user  

**ES 🇲🇽**
- El login responde con error del servidor  
- El error se maneja correctamente  
- Se informa al usuario  

---

## 🧪 Demo Mode | Modo Demo

**EN 🇺🇸**  
To maintain functionality:

- Mock data is used when auth fails  
- Full UI flow remains usable  

**ES 🇲🇽**  
Para mantener funcionalidad:

- Se usan datos simulados  
- La aplicación sigue funcionando  

---

## 🧩 Technical Challenges | Retos Técnicos

**EN 🇺🇸**
- Handling SSO limitations in desktop apps  
- API integration with restricted auth  
- Error handling and fallback logic  
- MVVM structure design  

**ES 🇲🇽**
- Manejo de SSO en escritorio  
- Integración con API limitada  
- Manejo de errores  
- Diseño MVVM  

---

## 🚀 Improvements | Mejoras

**EN 🇺🇸**
- Full SSO handling  
- Session management  
- Better backend integration  

**ES 🇲🇽**
- Soporte completo SSO  
- Manejo de sesiones  
- Mejor integración backend  

---

## 📚 Learning | Aprendizajes

**EN 🇺🇸**
- WPF application architecture  
- API consumption in desktop apps  
- Handling real-world backend limitations  
- MVVM design patterns  

**ES 🇲🇽**
- Arquitectura WPF  
- Consumo de APIs  
- Manejo de limitaciones reales  
- Patrón MVVM  

---

## 📊 Status | Estado

- Functional prototype / Prototipo funcional  
- Demo-ready / Listo para demostración  

---

# ⚙️ SYSTEM DATA (DO NOT EDIT FORMAT)

## PROJECT_DATA

name:
  en: Panacea Media Player
  es: Reproductor Panacea

description:
  en: Desktop media player consuming API with WPF and MVVM
  es: Reproductor de escritorio con WPF que consume API

problem:
  en: Desktop apps struggle with modern API authentication like SSO
  es: Apps de escritorio tienen problemas con autenticación moderna

solution:
  en: Structured MVVM app with fallback handling and API integration
  es: App estructurada con MVVM y manejo de fallback

stack:
  - C#
  - .NET Framework
  - WPF
  - MVVM
  - HttpClient

features:
  en:
    - Media playback
    - API integration
    - Error handling
  es:
    - Reproducción
    - Consumo API
    - Manejo de errores

architecture: MVVM desktop application

technical_challenges:
  en:
    - SSO auth handling
    - API limitations
    - Error management
  es:
    - Autenticación SSO
    - Limitaciones API
    - Manejo de errores

improvements:
  en:
    - SSO support
    - Session handling
  es:
    - Soporte SSO
    - Manejo de sesión

learning:
  en:
    - WPF
    - MVVM
    - API integration
  es:
    - WPF
    - MVVM
    - Integración API

status:
  en: Demo-ready
  es: Listo para demo

future:
  en:
    - Full authentication support
    - Backend improvements
  es:
    - Autenticación completa
    - Mejora backend

repo: https://github.com/Alucarduwu/PanaceaPlayer

---

## 🚀 Run

Open in Visual Studio → Build → Run  

---

## 👩‍💻 Author

**Anahí Lozano**

- LinkedIn: https://www.linkedin.com/in/anahi-lozano-de-lira-a4213a187  

---

<p align="center">
💜 Built to handle real-world system limitations
</p>
