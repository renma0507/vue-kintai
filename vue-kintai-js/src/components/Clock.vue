<template>
  <div class="clock-container">
    <h1 class="clock-time">現在の時刻: {{ currentTime }}</h1>
  </div>
</template>


<script>
export default {
  data() {
    return {
      currentTime: this.getCurrentTime(),
    };
  },
  methods: {
    getCurrentTime() {
      const now = new Date();
      return now.toLocaleTimeString(); // 時刻をローカル形式で取得
    },
  },
  mounted() {
    this.timer = setInterval(() => {
      this.currentTime = this.getCurrentTime();
    }, 1000); // 1秒ごとに更新
  },
  beforeDestroy() {
    clearInterval(this.timer); // コンポーネントが破棄される際にタイマーをクリア
  },
};
</script>


<style scoped>
.clock-container {
 position: fixed;
top: 40px;
left: 50%;
transform: translateX(-50%);
z-index: 9999;
pointer-events: none;

}

.clock-time {
  font-size: 48px;
  font-weight: bold;
  padding: 16px 32px;
  background-color: #f0f0f0;
  border: 8px solid #000;             /* ← 黒の太い枠線 */
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  color: #000;
}
</style>

