<template>
  <main>
    <List />
    <Clook />
    <Log />

    <!-- ボタンをまとめてスタイリングしやすく -->
    <div class="button-group">
      <Button />
      <Button2 />
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
  display: flex;
  justify-content: center; /* 中央寄せ */
  gap: 20px;                /* ボタン間の隙間 */
  flex-wrap: wrap;          /* 画面幅に応じて折り返し */
  margin-top: 30px;
}
</style>
