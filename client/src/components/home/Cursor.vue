<template>
    <div ref="cursorContainer" class="cursor-container">
      <div ref="customCursor" class="custom-cursor"></div>
    </div>
  </template>
  
  <style>
  body {
    cursor: default;
    margin: 0;
    overflow: hidden;
  }
  
  .cursor-container {
    position: fixed;
    top: 0;
    left: 0;
    pointer-events: none;
  }
  
  .custom-cursor {
    width: 40px;
    height: 40px;
    border-radius: 50%;

  background: radial-gradient(closest-side, var(--top-left-color), transparent);
 
  animation: expandAndContract1 4s infinite alternate;
}
@keyframes expandAndContract1 {
  0% {
    width: 40px;
    height: 40px;
  }
  100% {
    width: 50px;
    height: 50px;
  }
}

  </style>
  
  <script setup>
  import { ref, onMounted } from 'vue';
  
  const cursorContainer = ref(null);
  const customCursor = ref(null);
  
  const positionElement = (e) => {
    const mouseY = e.clientY -12;
    const mouseX = e.clientX -12;
  
    customCursor.value.style.transform = `translate3d(${mouseX}px, ${mouseY}px, 0)`;
  };
  
  onMounted(() => {
    // Get initial mouse position to set the initial position of the cursor
    const initialMouseX = window.innerWidth / 2;
    const initialMouseY = window.innerHeight / 2;
  
    customCursor.value.style.transform = `translate3d(${initialMouseX}px, ${initialMouseY}px, 0)`;
  
    window.addEventListener('mousemove', positionElement);
  });
  </script>
  