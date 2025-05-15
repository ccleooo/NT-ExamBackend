# C# 後端開發

## 題目一

請寫出一支API，能將表單A的附件資料寫至表單B：

- Action：`POST`
- Router：`/api/file/copy`
- Content-Type：`application/json`
- JSON 內容如下：

```json
{
  "source": "{RequisitionID}",
  "target": "{RequisitionID}"
}
```

## 預期結果

### 基本

呼叫成功後，資料應成功寫入資料庫 `FM7T_表單B_F` 資料表，包含以下欄位：

| 欄位名稱     | 說明                 |
|--------------|----------------------|
| AutoCounter  | 自動編號（PK）       |
| AccountID    | 上傳人帳號(同source) |
| MemberName   | 上傳人姓名(同source) |
| RequisitionID| 對應表單單號         |
| DiagramID    | 表單流程圖代碼       |
| ProcessID    | 表單流程關卡代碼(Start01)|
| NFileName    | 系統儲存檔名(同source)|
| OFileName    | 原始檔案名稱(同source)|
| FileSize     | 檔案大小（byte）(同source)|
| DraftFlag    | 是否為草稿(同source) |
| Remark       | 備註(同source)       |

### 進階：附件檔案資料複製與實體檔案處理

在完成附件資料複製至表單 B 的同時，**實體檔案**也必須一併複製到表單對應的檔案目錄下。

---

#### 📁 檔案複製需求

- 檔案來源與目標：  
  從資料表 `FM7T_表單A_F` 複製附件資料與實體檔案，寫入 `FM7T_表單B_F`

- **實體檔案複製路徑：**  
SELECT FilePath FROM FSe7en_Tep_IdentifySetting + NFileName
- **說明：**
- `FilePath`：從 `FSe7en_Tep_IdentifySetting` 取得表單目錄路徑（例如：`C:\NTWEB\AutoWeb3\database\project\BPM\BPMPro\object`）
- `NFileName`：系統儲存檔名（例如：`CI\2025-04\6c4a987f-5ff8-4f81-926a-084a23b5063c.pdf`）

➜ 實際檔案完整路徑組合：`C:\NTWEB\AutoWeb3\database\project\BPM\BPMPro\object\CI\2025-04\6c4a987f-5ff8-4f81-926a-084a23b5063c.pdf`

#### 注意事項

- 需確認複製目標資料夾存在，若無則建立。
- 檔案名稱若有重複風險，可加上 GUID 或時間戳記處理命名。
- 複製檔案失敗需回傳錯誤訊息，避免資料表寫入與實體不一致。
- FM7T_表單B_F欄位須為新實體路徑

---
