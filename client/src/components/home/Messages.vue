<template>
  <div class="form fade-in-on-scroll">
    <div class="form-header">
      <h1>Say Hi</h1>
    </div>
    <div>
      <form>
        <div class="row">
          <div class="six columns">
            <input type="text" placeholder="Your name" v-model="form.name" required maxlength="70" />
          </div>
          <div class="six columns">
            <input type="email" placeholder="Your email" v-model="form.email" required maxlength="200" />
          </div>
        </div>
        <textarea placeholder="Hi Sara …" v-model="form.content" required maxlength="1000"></textarea>
        <div class="row">
          <div class="six columns">
            <button class="button send-button icon-rotate" v-on:click.prevent="Send">
              <span>Send</span>
              <img class="icon" src="@/assets/home/images/send.png" alt="Send">
            </button>
          </div>
        </div>
      </form>
    </div>
  </div>
</template>


<script>
import messagesService from '@/services/messagesService'
import { useToast } from 'vue-toastification'

export default {
  data() {
    return {
      form: {
        name: '',
        email: '',
        content: ''
      }
    }
  },
  methods: {
    Send() {      
      const toast = useToast()
      try {
        messagesService.create(this.form).then(response => {
          this.ClearForm()
          if (response.status == 200)
            toast.success("Message sent. Thank you!")
        })
      }
      catch (errorMsg) {
        toast.error("Something went wrong")
      }
    },
    ClearForm() {
      this.form = ''
    }
  }
}
</script>


