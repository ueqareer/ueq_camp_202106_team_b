<template>
  <div class="home">
    <div class="home__content">
      <h1>タイトル</h1>
      <h3>今日も頑張りましょう!!!!!</h3>
      <the-button to="https://ueq-project.web.app/result/" description="START" class="home__button"></the-button>
    </div>
    <div class="home__background">
      <img src="../assets/Unitychan6.png" width="400" height="680" alt=""/>
      <img style="margin-top: -150px;" src="../assets/Unitychan2.png" width="400" height="650" alt=""/>
      <img src="../assets/Unitychan3.png" width="300" height="600" alt=""/>
    </div>
  </div>
</template>

<script>
// @ is an alias to /src
import TheButton from "@/components/TheButton";

export default {
  name: 'Home',
  components: {
    TheButton
  }
}
</script>
<style lang="scss" scoped>
.home {
  width: 100vw;
  height: 100vh;

  &__content {
    width: 100%;
    height: 100%;
    position: fixed;
    top: 0;
    z-index: 2;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    color: #7F74FC;
  }

  &__background {
    width: 100%;
    height: 100%;
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    align-items: center;
    position: fixed;
    top: 0;
    z-index: -1;


    img {
      opacity: 0.2;
    }
  }
}

</style>