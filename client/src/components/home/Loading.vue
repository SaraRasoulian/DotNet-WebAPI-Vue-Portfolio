<template>
    <div class="loading-wrapper">
        <div class="loading">
            <div></div>
            <div>
                <div></div>
            </div>
        </div>
    </div>
</template>
<style>
@keyframes loading {
    0% {
        transform: rotate(0);
    }

    100% {
        transform: rotate(360deg);
    }
}

.loading div {
    box-sizing: border-box !important;
}

.loading>div {
    position: absolute;
    width: 36px;
    height: 36px;
    top: 82px;
    left: 82px;
    border-radius: 50%;
    border: 4px solid #000;
    border-color: #b5b9c8 transparent #b5b9c8 transparent;
    animation: loading 1s linear infinite;
}

.loading>div:nth-child(2) {
    border-color: transparent;
}

.loading>div:nth-child(2) div {
    position: absolute;
    width: 100%;
    height: 100%;
    transform: rotate(45deg);
}

.loading>div:nth-child(2) div:before,
.loading>div:nth-child(2) div:after {
    content: "";
    display: block;
    position: absolute;
    width: 4px;
    height: 4px;
    top: -4px;
    left: 12px;
    background: #b5b9c8;
    border-radius: 50%;
    box-shadow: 0 32px 0 0 #b5b9c8;
}

.loading>div:nth-child(2) div:after {
    left: -4px;
    top: 12px;
    box-shadow: 32px 0 0 0 #b5b9c8;
}

.loading-wrapper {
    width: 201px;
    height: 201px;
    overflow: hidden;
    display: block;
    margin: 0 auto;
}

.loading {
    width: 100%;
    height: 100%;
    position: relative;
    transform: translateZ(0) scale(1);
    backface-visibility: hidden;
    transform-origin: 0 0;
}

.loading div {
    box-sizing: content-box;
}
</style>
