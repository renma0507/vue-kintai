<script setup>
import { ref, computed } from 'vue'
import List from '../components/List.vue'

const attendanceList = ref([
  {
    name: '山田 太郎',
    date: '2025-06-24',
    startTime: '09:00',
    endTime: '18:00',
    breakStart: '12:00',
    breakEnd: '13:00',
  }
])

const selectedName = ref('')
const selectedDate = ref('2025-06-24')

// 修正後の入力欄
const editedTime = ref({
  startTime: '',
  endTime: '',
  breakStart: '',
  breakEnd: ''
})

const selectedRecord = computed(() =>
  attendanceList.value.find(
    (item) => item.name === selectedName.value && item.date === selectedDate.value
  )
)

function applyEdits() {
  if (!selectedRecord.value) return

  Object.assign(selectedRecord.value, editedTime.value)
  alert('申請しました')
}
</script>

<template>
  <div class="container">
  
  
      <List/>
 

    <!-- メインエリア -->
    <div class="main">
      <!-- 日付 -->
      <div class="date-input" >
        <!-- <label>日付:</label> -->
        <input type="date" v-model="selectedDate" class="date"/>
      </div>


      <!-- 勤怠データ表示 -->
      <div class="table-area">
        <table class="time-table">
          <thead>
            <tr><th>出勤</th><th>退勤</th><th>休憩</th><th>戻り</th></tr>
          </thead>
          <tbody>
            <tr>
              <td>{{ selectedRecord?.startTime || '-' }}</td>
              <td>{{ selectedRecord?.endTime || '-' }}</td>
              <td>{{ selectedRecord?.breakStart || '-' }}</td>
              <td>{{ selectedRecord?.breakEnd || '-' }}</td>
            </tr>
          </tbody>
        </table>

        <table class="time-table">
          <thead>
            <tr><th>出勤</th><th>退勤</th><th>休憩</th><th>戻り</th></tr>
          </thead>
          <tbody>
            <tr>
              <td><input type="time" class="bigtime"v-model="editedTime.startTime" /></td>
              <td><input type="time"  class="bigtime"v-model="editedTime.endTime" /></td>
              <td><input type="time"  class="bigtime"v-model="editedTime.breakStart" /></td>
              <td><input type="time" class="bigtime" v-model="editedTime.breakEnd" /></td>
            </tr>
          </tbody>
        </table>
      </div>

      <!-- 申請ボタン -->
      <div class="apply-button">
        <button @click="applyEdits">申請</button>
      </div>
    </div>
  </div>
</template>

<style scoped>
.bigtime{
  width: 70%;
  height: 100px;
  font-size: 45px;
}
.container {
  display: flex;
  height: 100vh;
  font-size: 18px; /* 少し大きく */
}

/* メインエリア（右） */
.main {
  flex: 1;
  padding: 60px; /* 広くする */
  background-color: #fff;
  font-size: 1.2em; /* コンテンツを拡大 */
}

/* 日付入力 */
.date-input {
  margin-bottom: 30px;
  width: 435px;             /* 幅を広げる */
  font-size: 1.5em;         /* テキストとカレンダーアイコンを拡大 */
  padding: 12px 16px;       /* 内側余白を広げる */
  border: 2px solid #999;
  border-radius: 8px;
  box-sizing: border-box;
}
.label{font-size: large;

}
.date{
   width: 400px;
  height: 100px;
  font-size: 1.6em;
  padding: 10px 20px;
}


/* 勤怠テーブル2つ */
.table-area {
  display: flex;
  flex-direction: column;
  gap: 20px;
}

/* 表の見た目 */
.time-table {
  width:150%;
  border-collapse: collapse;
  font-size: 1.2em;
}
.time-table th {
  border: 1px solid #888;
  padding: 16px;
  text-align: center;
  font-size: 16px;
}
.time-table td{
    border: 1px solid #888;
  padding: 16px;
  text-align: center;
  font-size: 50px;
}

.apply-button {
  position: fixed;     /* ← 画面に対して固定 */
  bottom: 150px;        /* 下から40px */
  right: 40px;         /* 右から40px */
  z-index: 1000;       /* 必要なら上に重ねる */
}

.apply-button button {
  font-size: 1.2em;
  padding: 12px 24px;
  cursor: pointer;
}




</style>
