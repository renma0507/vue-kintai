<template>
  <main>
    <List />
    <Clook />
    <Log />

    <!-- ボタンをまとめてスタイリングしやすく -->
    <div class="button-group">
      <Button />
      <Button2 /> 
    </div>
    <div class="button-group2">
      <Button3 />
      <Button4 />
   </div>

    <RouterView />
  </main>
</template>

<script setup>
import { RouterLink, RouterView } from 'vue-router'
import List from '../components/List.vue'
import Clook from '../components/Clock.vue'
import Log from '../components/Log.vue'
import Button from '../components/Button.vue'
import Button2 from '../components/Button2.vue'
import Button3 from '../components/Button3.vue'
import Button4 from '../components/Button4.vue'
</script>

<style scoped>


.button-group {
  display: grid;
  grid-template-columns: repeat(2, 200px);
  grid-template-rows: 140px;
  gap: 250px;
  width: 420px;          /* 200px×2 + 20px */
  margin-left: 50%;
  margin-right: auto;    /* ← これで横中央 */
  justify-content: center;
  align-items: center;
}
.button-group2
{
  display: grid;
  grid-template-columns: repeat(2, 200px);
  grid-template-rows: 140px;
  gap: 250px;
  width: 420px;          /* 200px×2 + 20px */
  margin-left: 50%;
  margin-right: auto;  
  margin-top:25%;  /* ← これで横中央 */
  justify-content: center;
  align-items: center;
}


.button-group :deep(button),
.button-group2 :deep(button) {
  width: 240px;
  height: 140px;
  font-size: 1.8rem;
  font-weight: bold;
  background-color: #007bff;
  color: white;
  border: none;
  border-radius: 12px;
  box-shadow: 0 6px 12px rgba(0, 0, 0, 0.25);
  cursor: pointer;
  transition: transform 0.2s;
}

.button-group :deep(button):hover,
.button-group2 :deep(button):hover {
  transform: scale(1.05);
}

</style>
