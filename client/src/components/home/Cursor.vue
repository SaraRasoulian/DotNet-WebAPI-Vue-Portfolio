<template>
  <div ref="cursorContainer" class="cursor-container">
    <div ref="customCursor" class="custom-cursor"></div>
  </div>
</template>
  
<script setup>
import { ref, onMounted } from 'vue';

const cursorContainer = ref(null);
const customCursor = ref(null);

const positionElement = (e) => {
  const mouseY = e.clientY - 14;
  const mouseX = e.clientX - 18;
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
  