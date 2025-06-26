<template>
  <div class="app-container">
    <aside class="sidebar">
      <List @update-selected="selectNumber = $event" />
    </aside>

    <main class="main-content">
        <Clock :user-id="selectNumber" />

      <div class="button-grid">
        <Button  :user-id="selectNumber" />
        <Button2 :user-id="selectNumber" />
        <Button3 :user-id="selectNumber" />
        <Button4 :user-id="selectNumber" />
      </div>

      <div class="link-container">
        <router-link to="/">ホーム画面へ</router-link>
        <router-link to="/management">管理画面へ</router-link>
      </div>
    </main>

    <aside class="log-panel">
      <Log :user-id="selectNumber" />
    </aside>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import List    from './components/List.vue'
import Clock   from './components/Clock.vue'
import Log     from './components/Log.vue'
import Button  from './components/Button.vue'
import Button2 from './components/Button2.vue'
import Button3 from './components/Button3.vue'
import Button4 from './components/Button4.vue'

const selectNumber = ref(null)
</script>

<style>
html, body {
  margin: 0;
  height: 100%;
}

.app-container {
  display: grid;
  grid-template-columns: 200px 1fr 200px;
  min-height: 100vh;       /* 高さが足りなくても伸びる */
}

/* 左右は個別スクロールOK */
.sidebar,
.log-panel {
  background: #b3b3b3;
  padding: 1rem;
  overflow-y: auto;
}

/* 中央はスクロールさせず、常に全要素を表示 */
.main-content {
  background: #fff;
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 2rem;
  overflow: visible;       /* ←ここを auto → visible に */
}

/* 時計部分 */
/* .clock-box {
  border: 8px solid #000;
  background: #eee;
  padding: 1rem 2rem;
  text-align: center;
} */

/* ボタングリッド */
.button-grid {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  gap: 2rem;
  margin: 2rem 0;
  /* width: 100%; */
  max-width: 600px;
  padding-top: 200px;
}

/* 下部リンク */
.link-container {
  margin-top: auto;
  text-align: center;
}
.link-container a {
  margin: 0 1rem;
  color: #28a745;
  text-decoration: none;
}

select{
      width: 175px;
    height: 300px;
}
</style>
