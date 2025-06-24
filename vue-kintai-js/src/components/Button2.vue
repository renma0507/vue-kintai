<template>
  <div class="clockin-wrapper">
    <button 
      class="clockin-button"
      :disabled="!selectedName"
      @click="sendClockIn"
    >
      退勤
    </button>

    <p v-if="submitted">
      {{ selectedName }}さんが {{ currentTime }} に出勤しました。
    </p>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import axios from 'axios'

const props = defineProps({
  selectedName: String,
  currentTime: String
})

const submitted = ref(false)

const sendClockIn = async () => {
  try {
    await axios.post('https://example.com/api/clockin', {
      name: props.selectedName,
      clockInTime: props.currentTime
    })
    submitted.value = true
    console.log('出勤情報送信成功')
  } catch (e) {
    console.error('送信失敗', e)
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
