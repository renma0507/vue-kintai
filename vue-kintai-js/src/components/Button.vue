<template>
  <div class="clockin-wrapper">
    <button 
      class="clockin-button"

      @click="sendClockIn"
    >
      出勤
    </button>

    <p v-if="submitted">
      {{ selectedName }}さんが {{ currentTime }} に出勤しました。
    </p>
  </div>
  <!-- ボタンのところにdisabledを入れたい -->
</template>

<script setup>
import { ref } from 'vue'
import axios from 'axios'
import { definedProps } from './List.vue'

const props = defineProps(['selectedNumber'])
console.log(props)
const allDate = new Date()
const selectedName = ref('')
const userId = ref('')

const submitted = ref(false)

const sendClockIn = async () => {
  console.log('出勤ボタンがクリックされました')
  const month = allDate.getMonth() + 1 // 月は0から始まるため+1
  const day = allDate.getDate() // 日を取得
  const hours = allDate.getHours() // 時間を取得
  const minutes = allDate.getMinutes() // 分を取得
  const date = month + '/' + day 
  const time = hours + ':' + (minutes < 10 ? '0' + minutes : minutes) // 分が1桁の場合は0を追加
  const status = 'attend'
  const payload= {
    userId: selectedNumber,
    status : 'attend',
    date : date,
    time : time
  }
 console.log('送信するデータ:', payload)
  try {
    await axios.post('https://localhost:55925/vue-kintai / AttendTime', payload,{
    headers: { 'Content-Type': 'application/json' }
  })
     alert('出勤情報を送信しました')
    userId.value = ''
    status.value = ''
    date = ''
    time= ''
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
