<template>
  <div class="clockin-wrapper">
    <button class="clockin-button" @click="sendClockIn">
      休憩
    </button>
    <p v-if="submitted">
      <Log :attendancelog="attendanceLog"/>
    </p>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import axios from 'axios'
import { defineProps } from 'vue'
import Log from '../components/Log.vue'
const props = defineProps({
  selectedName: String,
  userId: Number
})
const userId = ref() 
const submitted = ref(false)
const currentTime = ref('')
const attendanceLog = "休憩"

const sendClockIn = async () => {
console.log('休憩ボタンがクリックされました',props.userId)
  // 日付と時間をフォーマット
  const now = new Date()
  const date = now.toISOString().split('T')[0] // 'YYYY-MM-DD'
  const time = `${String(now.getHours()).padStart(2, '0')}:${String(now.getMinutes()).padStart(2, '0')}`
  const payload = {
    userId: 1,     // 整数型
    status: 'go',         // 文字列型
    date: date,               // YYYY-MM-DD
    time: time                // HH:mm
  }
  console.log('送信データ:', JSON.stringify(payload, null, 2))
  try {
    await axios.post('https://localhost:55925/vue-kintai/AttendTime', payload, {
      headers: {
        'Content-Type': 'application/json'
      }
    })
    alert('出勤成功')
    submitted.value = true
    currentTime.value = time
  } catch (e) {
    console.error('送信失敗:', e.response?.data || e.message)
    alert('出勤に失敗しました')
  }
}
</script>


<style scoped>
.clockin-button {
  font-size: 1.2rem;
  padding: 10px 20px;
  background-color: #28a745;
  color: white;
  border: none;
  border-radius: 8px;
}
</style>　　社員リストのvueです 
